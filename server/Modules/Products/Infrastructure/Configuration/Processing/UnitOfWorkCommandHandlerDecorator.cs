using EShopModular.Common.Infrastructure;
using EShopModular.Modules.Products.Application.Configuration.Commands;
using EShopModular.Modules.Products.Application.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShopModular.Modules.Products.Infrastructure.Configuration.Processing;

internal class UnitOfWorkCommandHandlerDecorator<T> : IRequestHandler<T>, ICommandHandler
    where T : ICommand
{
    private readonly IRequestHandler<T> _decorated;
    private readonly IUnitOfWork _unitOfWork;
    private readonly EShopProductsContext _eshopProductsContext;

    public UnitOfWorkCommandHandlerDecorator(
        IRequestHandler<T> decorated,
        IUnitOfWork unitOfWork,
        EShopProductsContext eshopProductsContext)
    {
        _decorated = decorated;
        _unitOfWork = unitOfWork;
        _eshopProductsContext = eshopProductsContext;
    }

    public async Task Handle(T command, CancellationToken cancellationToken)
    {
        await _decorated.Handle(command, cancellationToken);

        if (command is InternalCommandBase)
        {
            var internalCommand =
                await _eshopProductsContext.InternalCommands.FirstOrDefaultAsync(
                    x => x.Id == command.Id,
                    cancellationToken: cancellationToken);

            if (internalCommand != null)
            {
                internalCommand.ProcessedDate = DateTime.UtcNow;
            }
        }

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}