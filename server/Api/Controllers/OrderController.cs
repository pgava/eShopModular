using eShopModular.Application.Contracts;
using eShopModular.Application.Orders;
using eShopModular.Application.Orders.AddOrder;
using eShopModular.Application.Orders.GetShippingCost;
using eShopModular.Application.Products;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart = eShopModular.Application.Orders.AddOrder.ShoppingCart;

namespace eShopModular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IEShopCmcModule _eShopCmcModule;
        public OrderController(IEShopCmcModule eShopCmcModule)
        {
            _eShopCmcModule = eShopCmcModule;
        }

        [HttpGet("shipping/{cost}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> CalculateShippingCost(decimal cost)
        {
            var shippingCost = await _eShopCmcModule.ExecuteQueryAsync(new GetShippingCostQuery {OrderPrice = cost});

            return Ok(shippingCost);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOrder(AddOrderRequest request)
        {
            await _eShopCmcModule.ExecuteCommandAsync(new AddOrderCommand
                (
                    request.Currency,
                    request.ExchangeRate,
                    request.ShippingCost,
                    request.TotalCost,
                    request.Products.Select(x => new ShoppingCart
                    (
                        x.Quantity,
                        new ProductViewModel
                        (
                            x.Product.Id,
                            string.Empty,
                            x.Product.Price,
                            string.Empty,
                            string.Empty
                        )
                    )).ToList()
                ));

            return Ok();
        }
    }
}
