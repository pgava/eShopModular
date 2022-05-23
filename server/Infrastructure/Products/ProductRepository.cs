using System.Runtime.Intrinsics;
using eShopCmc.Domain.Orders;
using eShopCmc.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eShopCmc.Infrastructure.Products;

public class ProductRepository : IProductRepository
{
    private readonly EShopCmcContext _context;
    public ProductRepository(EShopCmcContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsAsync(CancellationToken ct)
    {
        // TODO: Find a better way to seed the database 
        await SeedProductsData(ct);
        return await _context.Products.ToListAsync(ct);
    }

    private async Task SeedProductsData(CancellationToken ct)
    {
        if (_context.Products.Any())
        {
            return;
        }
        
        Random rand = new Random();
        var products = new List<Product>();
        for (var productIndex = 0; productIndex < 12; productIndex++)
        {
            int rndNumber = rand.Next(1, 101);
            var price = (decimal)(Math.Round(rndNumber * 0.95));
            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Name = $"Product Name-{productIndex}",
                Description = $"This is the description for product {productIndex}",
                ImageUrl = $"Image for product {productIndex}",
                Price = price
            });
        }
        
        _context.Products.AddRange(products);
        
        await _context.SaveChangesAsync(ct);
    }
}