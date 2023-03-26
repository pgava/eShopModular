using EShopModular.Modules.Orders.Application.Orders.GetOrderDetails;
using EShopModular.Modules.Orders.IntegrationTests.SeedWork;
using FluentAssertions;

namespace EShopModular.Modules.Orders.IntegrationTests;

public class OrderCreateTests : TestBase
{
    [Fact]
    public async Task OrderCreate_Test()
    {
        var orderId = await OrderCreateHelper.CreateOrderAsync(EShopOrdersModule, ExecutionContext);
        
        var orderDetails = await EShopOrdersModule.ExecuteQueryAsync(new GetOrderDetailsQuery(orderId));
        orderDetails.Should().NotBeNull();
    }
}