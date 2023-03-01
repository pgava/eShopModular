using eShopModular.Common.Domain;

namespace eShopModular.Domain.Orders;

public class OrderItemId : TypedIdValueBase
{
    public OrderItemId(Guid value)
        : base(value)
    {
    }
}