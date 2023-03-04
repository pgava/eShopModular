using EShopModular.Modules.Products.Application.Configuration.Queries;
using EShopModular.Modules.Products.Domain.Products;

namespace EShopModular.Modules.Products.Application.Products.GetAllProducts;

public class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetProductsAsync(cancellationToken);

        return products.Select(x => new ProductDto(
            x.Id.Value,
            x.Name,
            x.Price,
            x.ImageUrl,
            x.Description)).ToList();
    }
}