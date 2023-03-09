using EShopModular.Common.Infrastructure;
using EShopModular.Modules.Orders.Application.Configuration.Commands;
using EShopModular.Modules.Orders.Application.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShopModular.Modules.Orders.Infrastructure.Configuration.Processing;

internal class UnitOfWorkCommandHandlerDecorator<T> : IRequestHandler<T>, ICommandHandler
    where T : ICommand
{
    private readonly IRequestHandler<T> _decorated;
    private readonly IUnitOfWork _unitOfWork;
    private readonly EShopOrdersContext _eshopOrdersContext;

    public UnitOfWorkCommandHandlerDecorator(
        IRequestHandler<T> decorated,
        IUnitOfWork unitOfWork,
        EShopOrdersContext eshopOrdersContext)
    {
        _decorated = decorated;
        _unitOfWork = unitOfWork;
        _eshopOrdersContext = eshopOrdersContext;
    }

    public async Task Handle(T command, CancellationToken cancellationToken)
    {
        await _decorated.Handle(command, cancellationToken);

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

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}