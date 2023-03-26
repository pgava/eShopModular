using EShopModular.Modules.Orders.Application.Contracts;
using EShopModular.Modules.Orders.Application.Orders.AddOrder;
using EShopModular.Modules.Orders.IntegrationTests.SeedWork;

namespace EShopModular.Modules.Orders.IntegrationTests;

internal static class OrderCreateHelper
{
    public static async Task<Guid> CreateOrderAsync(
        IEShopOrdersModule orderModule,
        ExecutionContextMock executionContext)
    {
        var orderId = await orderModule.ExecuteCommandAsync(
            new AddOrderCommand(
                Guid.NewGuid(), "AUD", 1, 10, 100,
                new List<OrderItemDto>(new[]
                {
                    new OrderItemDto(
                        1, new ProductOrderDto(Guid.NewGuid(), "p1", 1, "img", "desc")
                    )
                })
            ));
        
        return orderId;
    }
}