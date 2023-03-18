using EShopModular.Modules.Orders.IntegrationEvents;
using EShopModular.Modules.Products.Application.Configuration.Commands;
using MediatR;

namespace EShopModular.Modules.Products.Application.Products
{
    internal class OrderCreatedIntegrationEventHandler : INotificationHandler<OrderCreatedIntegrationEvent>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        public OrderCreatedIntegrationEventHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public Task Handle(OrderCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            // Do something with the event
            return Task.CompletedTask;
        }
    }
}