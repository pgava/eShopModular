using eShopModular.Common.Domain;

namespace eShopModular.Modules.Orders.Domain.Orders;

public class OrderId : TypedIdValueBase
{
    public OrderId(Guid value)
        : base(value)
    {
    }
}