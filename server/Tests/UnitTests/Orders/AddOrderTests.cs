using System.Threading;
using AutoFixture;
using EShopModular.Modules.Orders.Application.Orders.AddOrder;
using EShopModular.Modules.Orders.Domain.Orders;
using Moq;
using Xunit;

namespace EShopModular.UnitTests.Orders
{
    public class AddOrderTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IOrderRepository> _orderRepository;

        public AddOrderTests()
        {
            _fixture = new Fixture();
            _orderRepository = new Mock<IOrderRepository>();
        }

        [Fact]
        public async void AddOrder_ShouldAddOrder()
        {
            // Arrange
            var command = _fixture.Build<AddOrderCommand>().Create();
            var sut = new AddOrderCommandHandler(_orderRepository.Object);

            // Act
            _ = await sut.Handle(command, CancellationToken.None);

            // Assert
            _orderRepository.Verify(r =>
                r.AddOrderAsync(
                    It.Is<Order>(o => o.ShippingCost == command.ShippingCost &&
                                      o.TotalCost == command.TotalCost),
                    CancellationToken.None));
        }
    }
}
