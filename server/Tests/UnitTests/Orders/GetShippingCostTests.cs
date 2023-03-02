﻿using System.Threading;
using eShopModular.Modules.Orders.Application.Orders.GetShippingCost;
using FluentAssertions;
using Xunit;

namespace eShopModular.UnitTests.Orders
{
    public class GetShippingCostTests
    {
        [Theory]
        [InlineData(10, 10)]
        [InlineData(50, 10)]
        [InlineData(100, 20)]
        public async void ShippingCost_ShouldReturnCorrectShippingCost(int orderCost, int shippingCost)
        {
            // Arrange
            var sut = new GetShippingCostQueryHandler();

            // Act
            var response = await sut.Handle(
                new GetShippingCostQuery
                {
                    OrderPrice = orderCost
                },
                CancellationToken.None);

            // Assert
            response.Should().Be(shippingCost);
        }

    }
}
