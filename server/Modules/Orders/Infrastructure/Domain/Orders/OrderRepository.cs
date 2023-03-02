using eShopModular.Modules.Orders.Domain.Orders;
using Serilog;

namespace eShopModular.Modules.Orders.Infrastructure.Domain.Orders;

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
        try
        {
            await _context.Orders.AddAsync(order, ct);
            await _context.SaveChangesAsync(ct);
        }
        catch (Exception ex)
        {
            _logger.Error("AddOrderAsync -> Error - {Message}", ex.Message);
            throw;
        }
    }
}