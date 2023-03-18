using EShopModular.Common.Infrastructure.EventBus;

namespace EShopModular.Modules.Orders.IntegrationEvents;

public class OrderCreatedIntegrationEvent : IntegrationEvent
{
    public Guid OrderId { get; }

    public OrderCreatedIntegrationEvent(Guid id, DateTime occurredOn, Guid orderId)
        : base(id, occurredOn)
    {
        OrderId = orderId;
    }
}