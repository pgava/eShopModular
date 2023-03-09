#nullable disable
using EShopModular.Common.Application.Outbox;
using EShopModular.Common.Infrastructure.InternalCommands;
using EShopModular.Modules.Products.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EShopModular.Modules.Products.Infrastructure;

public class EShopProductsContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public DbSet<InternalCommand> InternalCommands { get; set; }

    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    private readonly ILoggerFactory _loggerFactory;

    public EShopProductsContext(DbContextOptions<EShopProductsContext> options, ILoggerFactory loggerFactory)
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