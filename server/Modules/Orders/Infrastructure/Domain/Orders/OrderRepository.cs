using EShopModular.Modules.Orders.Domain.Orders;
using Serilog;

namespace EShopModular.Modules.Orders.Infrastructure.Domain.Orders;

public class OrderRepository : IOrderRepository
{
    private readonly EShopOrdersContext _context;
    private readonly ILogger _logger;

    public OrderRepository(EShopOrdersContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task AddOrderAsync(Order order, CancellationToken ct)
    {
        await _context.Orders.AddAsync(order, ct);
    }

    public async Task<Order?> GetByIdAsync(OrderId id)
    {
        return await _context.Orders.FindAsync(id);
    }
}