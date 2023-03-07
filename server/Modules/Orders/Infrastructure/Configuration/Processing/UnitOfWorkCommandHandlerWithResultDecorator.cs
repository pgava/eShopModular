using EShopModular.Common.Infrastructure;
using EShopModular.Modules.Orders.Application.Configuration.Commands;
using EShopModular.Modules.Orders.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EShopModular.Modules.Orders.Infrastructure.Configuration.Processing;

internal class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult>
    where T : ICommand<TResult>
{
    private readonly ICommandHandler<T, TResult> _decorated;
    private readonly IUnitOfWork _unitOfWork;
    private readonly EShopOrdersContext _eshopOrdersContext;

    public UnitOfWorkCommandHandlerWithResultDecorator(
        ICommandHandler<T, TResult> decorated,
        IUnitOfWork unitOfWork,
        EShopOrdersContext eshopOrdersContext)
    {
        _decorated = decorated;
        _unitOfWork = unitOfWork;
        _eshopOrdersContext = eshopOrdersContext;
    }

    public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
    {
        var result = await this._decorated.Handle(command, cancellationToken);

        if (command is InternalCommandBase<TResult>)
        {
            var internalCommand = await _eshopOrdersContext.InternalCommands.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

            if (internalCommand != null)
            {
                internalCommand.ProcessedDate = DateTime.UtcNow;
            }
        }

        await this._unitOfWork.CommitAsync(cancellationToken);

        return result;
    }
}