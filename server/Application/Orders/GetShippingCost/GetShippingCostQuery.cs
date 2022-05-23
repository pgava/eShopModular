using eShopCmc.Application.Configuration.Queries;

namespace eShopCmc.Application.Orders.GetShippingCost;

public class GetShippingCostQuery : QueryBase<int>
{
    public decimal OrderPrice { get; set; }
}