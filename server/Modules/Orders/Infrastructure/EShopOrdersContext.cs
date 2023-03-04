#nullable disable
using EShopModular.Modules.Orders.Domain.Countries;
using EShopModular.Modules.Orders.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EShopModular.Modules.Orders.Infrastructure;

public class EShopOrdersContext : DbContext
{
    public DbSet<Country> Countries { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    private readonly ILoggerFactory _loggerFactory;

    public EShopOrdersContext(DbContextOptions<EShopOrdersContext> options, ILoggerFactory loggerFactory)
        : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
#nullable enable