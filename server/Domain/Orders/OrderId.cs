namespace eShopModular.Domain.Orders;

public class OrderId : TypedIdValueBase
{
    public OrderId(Guid value)
        : base(value)
    {
    }
}