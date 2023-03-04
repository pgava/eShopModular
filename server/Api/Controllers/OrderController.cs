using EShopModular.Modules.Orders.Application.Contracts;
using EShopModular.Modules.Orders.Application.Orders.AddOrder;
using EShopModular.Modules.Orders.Application.Orders.GetShippingCost;
using Microsoft.AspNetCore.Mvc;

namespace EShopModular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IEShopOrdersModule _eShopOrdersModule;

        public OrderController(IEShopOrdersModule eShopOrdersModule)
        {
            _eShopOrdersModule = eShopOrdersModule;
        }

        [HttpGet("shipping/{cost}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> CalculateShippingCost(decimal cost)
        {
            var shippingCost = await _eShopOrdersModule.ExecuteQueryAsync(new GetShippingCostQuery { OrderPrice = cost });

            return Ok(shippingCost);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOrder(AddOrderRequest request)
        {
            await _eShopOrdersModule.ExecuteCommandAsync(new AddOrderCommand(
                    request.Currency,
                    request.ExchangeRate,
                    request.ShippingCost,
                    request.TotalCost,
                    request.OrderItems.Select(x => new OrderItemDto(
                        x.Quantity,
                        new ProductOrderDto(
                            x.Product.Id,
                            string.Empty,
                            x.Product.Price,
                            string.Empty,
                            string.Empty))).ToList()));

            return Ok();
        }
    }
}
