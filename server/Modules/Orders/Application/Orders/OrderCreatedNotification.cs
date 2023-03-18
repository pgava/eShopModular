using EShopModular.Common.Application.Events;
using EShopModular.Modules.Orders.Domain.Orders.Events;

namespace EShopModular.Modules.Orders.Application.Orders;

public class OrderCreatedNotification : DomainNotificationBase<OrderCreatedDomainEvent>
{
    public OrderCreatedNotification(OrderCreatedDomainEvent domainEvent, Guid id)
        : base(domainEvent, id)
    {
    }
}