using eShopCmc.Domain.Orders;
using Microsoft.Extensions.Logging;

namespace eShopCmc.Infrastructure.Orders;

public class OrderRepository : IOrderRepository
{
    private readonly EShopCmcContext _context;
    private readonly ILogger<OrderRepository> _logger;
    public OrderRepository(EShopCmcContext context, ILogger<OrderRepository> logger)
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
        catch(Exception ex)
        {
            _logger.LogError($"AddOrderAsync -> Error - {ex.Message}");
            throw;
        }
    }
}