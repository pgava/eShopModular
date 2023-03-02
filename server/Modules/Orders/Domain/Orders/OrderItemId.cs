using eShopModular.Common.Domain;

namespace eShopModular.Modules.Orders.Domain.Orders;

public class OrderItemId : TypedIdValueBase
{
    public OrderItemId(Guid value)
        : base(value)
    {
    }
}