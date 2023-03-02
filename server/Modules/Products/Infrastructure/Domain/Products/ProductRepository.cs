using eShopModular.Modules.Products.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace eShopModular.Modules.Products.Infrastructure.Domain.Products;

public class ProductRepository : IProductRepository
{
    private readonly EShopProductsContext _context;

    public ProductRepository(EShopProductsContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsAsync(CancellationToken ct)
    {
        return await _context.Products.ToListAsync(ct);
    }
}