#nullable disable
using eShopCmc.Domain.Countries;
using eShopCmc.Domain.Orders;
using eShopCmc.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eShopCmc.Infrastructure;

public class EShopCmcContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    private readonly ILoggerFactory _loggerFactory;
    
    public EShopCmcContext(DbContextOptions<EShopCmcContext> options, ILoggerFactory loggerFactory) : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
#nullable enable