namespace EShopModular.Modules.Orders.Domain.Orders;

public interface IOrderRepository
{
    Task AddOrderAsync(Order order, CancellationToken cancellationToken);

    Task<Order?> GetByIdAsync(OrderId id);
}
