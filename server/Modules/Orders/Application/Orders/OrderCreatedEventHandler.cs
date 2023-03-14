using EShopModular.Modules.Orders.Domain.Orders;
using EShopModular.Modules.Orders.Domain.Orders.Events;
using MediatR;

namespace EShopModular.Modules.Orders.Application.Orders
{
    internal class OrderCreatedEventHandler : INotificationHandler<OrderCreatedDomainEvent>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderCreatedEventHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(OrderCreatedDomainEvent @event, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(@event.OrderId);
        }
    }
}