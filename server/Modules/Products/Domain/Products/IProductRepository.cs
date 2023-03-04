namespace EShopModular.Modules.Products.Domain.Products;

public interface IProductRepository
{
    Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken);
}