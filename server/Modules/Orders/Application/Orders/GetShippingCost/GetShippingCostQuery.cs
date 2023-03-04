using EShopModular.Modules.Orders.Application.Configuration.Queries;

namespace EShopModular.Modules.Orders.Application.Orders.GetShippingCost;

public class GetShippingCostQuery : QueryBase<int>
{
    public decimal OrderPrice { get; set; }
}