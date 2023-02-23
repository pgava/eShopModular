using eShopModular.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace eShopModular.Infrastructure.Products;

public class ProductRepository : IProductRepository
{
    private readonly EShopCmcContext _context;
    public ProductRepository(EShopCmcContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsAsync(CancellationToken ct)
    {
        return await _context.Products.ToListAsync(ct);
    }
}