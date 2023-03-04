using EShopModular.Common.Domain;

namespace EShopModular.Modules.Orders.Domain.Orders;

public class OrderId : TypedIdValueBase
{
    public OrderId(Guid value)
        : base(value)
    {
    }
}