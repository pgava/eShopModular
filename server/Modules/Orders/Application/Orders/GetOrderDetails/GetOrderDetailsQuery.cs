using EShopModular.Modules.Orders.Application.Configuration.Queries;

namespace EShopModular.Modules.Orders.Application.Orders.GetOrderDetails;

public class GetOrderDetailsQuery : QueryBase<OrderDetailsDto>
{
    public GetOrderDetailsQuery(Guid orderId)
    {
        OrderId = orderId;
    }

    public Guid OrderId { get; }
}