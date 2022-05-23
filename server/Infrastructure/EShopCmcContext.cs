using eShopCmc.Domain.Countries;
using eShopCmc.Domain.Orders;
using eShopCmc.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace eShopCmc.Infrastructure;

public class EShopCmcContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public EShopCmcContext(DbContextOptions<EShopCmcContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}