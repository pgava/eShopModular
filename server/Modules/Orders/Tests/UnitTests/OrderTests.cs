using EShopModular.Modules.Orders.Domain.Orders;
using EShopModular.Modules.Orders.Domain.Orders.Events;
using EShopModular.Modules.Orders.Domain.UnitTests.SeedWork;
using FluentAssertions;

namespace EShopModular.Modules.Orders.Domain.UnitTests;

public class OrderTests : TestBase
{
    [Fact]
    public void CreateOrder_WhenDataIsCorrect_IsSuccessful()
    {
        var order = Order.CreateNew("AUD", 10, 100, 1, DateTime.Now);
        
        var orderCreatedEvents = AssertPublishedDomainEvents<OrderCreatedDomainEvent>(order);

        orderCreatedEvents.Count.Should().Be(1);
        orderCreatedEvents[0].OrderId.Should().Be(order.Id);
    }
}