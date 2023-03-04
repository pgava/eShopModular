using EShopModular.Modules.Products.Application.Contracts;
using EShopModular.Modules.Products.Application.Products;
using EShopModular.Modules.Products.Application.Products.GetAllProducts;
using Microsoft.AspNetCore.Mvc;

namespace EShopModular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IEShopProductsModule _eShopProductsModule;

        public ProductController(IEShopProductsModule eShopProductsModule)
        {
            _eShopProductsModule = eShopProductsModule;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts(int? page, int? perPage)
        {
            var products = await _eShopProductsModule.ExecuteQueryAsync(
                new GetAllProductsQuery());

            return Ok(products);
        }
    }
}
