using eShopModular.Application.Configuration.Queries;

namespace eShopModular.Application.Orders.GetShippingCost;

public class GetShippingCostQuery : QueryBase<int>
{
    public decimal OrderPrice { get; set; }
}