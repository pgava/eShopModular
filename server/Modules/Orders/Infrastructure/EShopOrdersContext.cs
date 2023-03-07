#nullable disable
using EShopModular.Common.Application.Outbox;
using EShopModular.Common.Infrastructure.InternalCommands;
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

    public DbSet<InternalCommand> InternalCommands { get; set; }

    public DbSet<OutboxMessage> OutboxMessages { get; set; }

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