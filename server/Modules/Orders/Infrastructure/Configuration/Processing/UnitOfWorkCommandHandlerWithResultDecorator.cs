using EShopModular.Common.Infrastructure;
using EShopModular.Modules.Orders.Application.Configuration.Commands;
using EShopModular.Modules.Orders.Application.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShopModular.Modules.Orders.Infrastructure.Configuration.Processing;

internal class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : IRequestHandler<T, TResult>, ICommandHandler
    where T : ICommand<TResult>
{
    private readonly IRequestHandler<T, TResult> _decorated;
    private readonly IUnitOfWork _unitOfWork;
    private readonly EShopOrdersContext _eshopOrdersContext;

    public UnitOfWorkCommandHandlerWithResultDecorator(
        IRequestHandler<T, TResult> decorated,
        IUnitOfWork unitOfWork,
        EShopOrdersContext eshopOrdersContext)
    {
        _decorated = decorated;
        _unitOfWork = unitOfWork;
        _eshopOrdersContext = eshopOrdersContext;
    }

    public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
    {
        var result = await _decorated.Handle(command, cancellationToken);

        if (command is InternalCommandBase<TResult>)
        {
            var internalCommand = await _eshopOrdersContext.InternalCommands.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

            if (internalCommand != null)
            {
                internalCommand.ProcessedDate = DateTime.UtcNow;
            }
        }

        await _unitOfWork.CommitAsync(cancellationToken);

        return result;
    }
}