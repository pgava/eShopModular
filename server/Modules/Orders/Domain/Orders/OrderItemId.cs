using EShopModular.Common.Domain;

namespace EShopModular.Modules.Orders.Domain.Orders;

public class OrderItemId : TypedIdValueBase
{
    public OrderItemId(Guid value)
        : base(value)
    {
    }
}