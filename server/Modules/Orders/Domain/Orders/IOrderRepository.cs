namespace eShopModular.Modules.Orders.Domain.Orders;

public interface IOrderRepository
{
    Task AddOrderAsync(Order order, CancellationToken cancellationToken);
}
