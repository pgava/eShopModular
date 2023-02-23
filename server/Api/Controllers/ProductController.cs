using eShopModular.Application.Contracts;
using eShopModular.Application.Products;
using eShopModular.Application.Products.GetAllProducts;
using Microsoft.AspNetCore.Mvc;

namespace eShopModular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IEShopCmcModule _eShopCmcModule;

        public ProductController(IEShopCmcModule eShopCmcModule)
        {
            _eShopCmcModule = eShopCmcModule;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts(int? page, int? perPage)
        {
            var products = await _eShopCmcModule.ExecuteQueryAsync(
                new GetAllProductsQuery());

            return Ok(products);
        }

        
    }
}
