using EShopModular.Common.Infrastructure.EventBus;
using EShopModular.Modules.Orders.Application.Configuration.Commands;
using EShopModular.Modules.Orders.Application.Orders.AddOrder;
using EShopModular.Modules.Orders.IntegrationEvents;
using MediatR;

namespace EShopModular.Modules.Orders.Application.Orders;

internal class OrderCreatedNotificationHandler : INotificationHandler<OrderCreatedNotification>
{
    private readonly ICommandsScheduler _commandsScheduler;
    private readonly IEventsBus _eventsBus;

    public OrderCreatedNotificationHandler(ICommandsScheduler commandsScheduler, IEventsBus eventsBus)
    {
        _commandsScheduler = commandsScheduler;
        _eventsBus = eventsBus;
    }

    public async Task Handle(OrderCreatedNotification notification, CancellationToken cancellationToken)
    {
        // Internal Command
        await _commandsScheduler.EnqueueAsync(
            new CreateTransactionCommand(Guid.NewGuid()));

        // Integration Event
        await _eventsBus.Publish(new OrderCreatedIntegrationEvent(
            Guid.NewGuid(),
            notification.DomainEvent.OccurredOn,
            notification.DomainEvent.OrderId.Value));
    }
}