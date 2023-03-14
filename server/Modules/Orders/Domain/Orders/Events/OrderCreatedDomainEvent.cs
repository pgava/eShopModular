using EShopModular.Common.Domain;

namespace EShopModular.Modules.Orders.Domain.Orders.Events
{
    public class OrderCreatedDomainEvent : DomainEventBase
    {
        public OrderCreatedDomainEvent(OrderId orderId)
        {
            OrderId = orderId;
        }

        public OrderId OrderId { get; }
    }
}