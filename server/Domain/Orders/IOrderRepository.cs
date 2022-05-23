namespace eShopCmc.Domain.Orders;

public interface IOrderRepository
{
    Task AddOrderAsync(Order order, CancellationToken cancellationToken);
}
