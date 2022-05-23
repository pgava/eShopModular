using eShopCmc.Application.Contracts;
using eShopCmc.Application.Orders;
using eShopCmc.Application.Orders.AddOrder;
using eShopCmc.Application.Orders.GetShippingCost;
using eShopCmc.Application.Products;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart = eShopCmc.Application.Orders.AddOrder.ShoppingCart;

namespace eShopCmc.Api.Controllers
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
                {
                    Currency = request.Currency,
                    ExchangeRate = request.ExchangeRate,
                    ShippingCost = request.ShippingCost,
                    TotalCost = request.TotalCost,
                    Products = request.Products.Select(x => new ShoppingCart
                    {
                        Quantity = x.Quantity,
                        Product = new ProductViewModel
                        {
                            Id = x.Product.Id,
                            Price = x.Product.Price
                        }
                    }).ToList()
                });

            return Ok();
        }
    }
}
