using EShopModular.Common.Infrastructure;
using EShopModular.Modules.Orders.Application.Configuration.Commands;
using EShopModular.Modules.Orders.Application.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShopModular.Modules.Orders.Infrastructure.Configuration.Processing;

internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T>
    where T : ICommand
{
    private readonly ICommandHandler<T> _decorated;
    private readonly IUnitOfWork _unitOfWork;
    private readonly EShopOrdersContext _eshopOrdersContext;

    public UnitOfWorkCommandHandlerDecorator(
        ICommandHandler<T> decorated,
        IUnitOfWork unitOfWork,
        EShopOrdersContext eshopOrdersContext)
    {
        _decorated = decorated;
        _unitOfWork = unitOfWork;
        _eshopOrdersContext = eshopOrdersContext;
    }

    public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
    {
        await this._decorated.Handle(command, cancellationToken);

        if (command is InternalCommandBase)
        {
            var internalCommand =
                await _eshopOrdersContext.InternalCommands.FirstOrDefaultAsync(
                    x => x.Id == command.Id,
                    cancellationToken: cancellationToken);

            if (internalCommand != null)
            {
                internalCommand.ProcessedDate = DateTime.UtcNow;
            }
        }

        await this._unitOfWork.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}