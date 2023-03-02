using eShopModular.Modules.Orders.Application.Configuration.Queries;

namespace eShopModular.Modules.Orders.Application.Orders.GetShippingCost;

public class GetShippingCostQueryHandler : IQueryHandler<GetShippingCostQuery, int>
{    
    public Task<int> Handle(GetShippingCostQuery request, CancellationToken cancellationToken)
    {
        if (request.OrderPrice < 0)
        {
            throw new Exception("Order price cannot be negative");
        }
        return Task.FromResult(request.OrderPrice <= 50 ? 10 : 20);
    }
}