#nullable disable
using eShopModular.Modules.Products.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eShopModular.Modules.Products.Infrastructure;

public class EShopProductsContext : DbContext
{
    public DbSet<Product> Products { get; set; }

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