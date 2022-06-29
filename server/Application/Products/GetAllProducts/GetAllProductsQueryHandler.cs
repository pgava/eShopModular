using eShopCmc.Application.Configuration.Queries;
using eShopCmc.Domain.Products;

namespace eShopCmc.Application.Products.GetAllProducts;

public class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, List<ProductViewModel>>
{
    private readonly IProductRepository _productRepository;
    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<List<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products =  await _productRepository.GetProductsAsync(cancellationToken);
        
        return products.Select(x => new ProductViewModel
        (
            x.Id.Value,
            x.Name,
            x.Price,
            x.ImageUrl,
            x.Description
        )).ToList(); 
    }
}