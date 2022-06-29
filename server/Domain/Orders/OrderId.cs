namespace eShopCmc.Domain.Orders;

public class OrderId : TypedIdValueBase
{
    public OrderId(Guid value)
        : base(value)
    {
    }
}