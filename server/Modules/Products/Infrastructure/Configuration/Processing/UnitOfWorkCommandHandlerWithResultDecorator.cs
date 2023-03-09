using EShopModular.Common.Infrastructure;
using EShopModular.Modules.Products.Application.Configuration.Commands;
using EShopModular.Modules.Products.Application.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShopModular.Modules.Products.Infrastructure.Configuration.Processing;

internal class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : IRequestHandler<T, TResult>, ICommandHandler
    where T : ICommand<TResult>
{
    private readonly IRequestHandler<T, TResult> _decorated;
    private readonly IUnitOfWork _unitOfWork;
    private readonly EShopProductsContext _eshopProductsContext;

    public UnitOfWorkCommandHandlerWithResultDecorator(
        IRequestHandler<T, TResult> decorated,
        IUnitOfWork unitOfWork,
        EShopProductsContext eshopProductsContext)
    {
        _decorated = decorated;
        _unitOfWork = unitOfWork;
        _eshopProductsContext = eshopProductsContext;
    }

    public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
    {
        var result = await _decorated.Handle(command, cancellationToken);

        if (command is InternalCommandBase<TResult>)
        {
            var internalCommand = await _eshopProductsContext.InternalCommands.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

            if (internalCommand != null)
            {
                internalCommand.ProcessedDate = DateTime.UtcNow;
            }
        }

        await _unitOfWork.CommitAsync(cancellationToken);

        return result;
    }
}