using System.Runtime.Intrinsics;
using eShopCmc.Domain.Orders;
using eShopCmc.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eShopCmc.Infrastructure.Products;

public class ProductRepository : IProductRepository
{
    private readonly EShopCmcContext _context;
    private readonly ILogger<ProductRepository> _logger;
    public ProductRepository(EShopCmcContext context, ILogger<ProductRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Product>> GetProductsAsync(CancellationToken ct)
    {
        try
        {
            // TODO: Find a better way to seed the database 
            await SeedProductsData(ct);
            return await _context.Products.ToListAsync(ct);
        }
        catch (Exception ex)
        {
            _logger.LogError($"GetProductsAsync -> Error occured - {ex.Message}");
            throw;
        }
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
                Name = $"Product-{productIndex}",
                Description = $"This is the description for product {productIndex}",
                ImageUrl = $"Image for product {productIndex}",
                Price = price
            });
        }
        
        _context.Products.AddRange(products);
        
        await _context.SaveChangesAsync(ct);
    }
}