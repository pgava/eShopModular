using eShopModular.Modules.Orders.Application.Configuration.Queries;

namespace eShopModular.Modules.Orders.Application.Orders.GetShippingCost;

public class GetShippingCostQuery : QueryBase<int>
{
    public decimal OrderPrice { get; set; }
}