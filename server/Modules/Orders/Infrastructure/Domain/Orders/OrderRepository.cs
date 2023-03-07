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

        // TODO: Remove below try-catch block. The commit is done in the UnitOfWork
        // try
        // {
        //     await _context.Orders.AddAsync(order, ct);
        //     await _context.SaveChangesAsync(ct);
        // }
        // catch (Exception ex)
        // {
        //     _logger.Error("AddOrderAsync -> Error - {Message}", ex.Message);
        //     throw;
        // }
    }
}