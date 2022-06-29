using System;
using System.Collections.Generic;
using eShopCmc.Application.Products.GetAllProducts;
using eShopCmc.Domain.Products;
using FluentAssertions;
using Moq;
using Xunit;

namespace eShopCmc.UnitTests.Products
{
    public class GetAllProductsQueryHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly List<Product> _products = new()
        {
            new Product { Id = new ProductId(Guid.NewGuid()), Name = "product1", ImageUrl ="img1", Price=1M },
            new Product { Id = new ProductId(Guid.NewGuid()), Name = "product2", ImageUrl ="test2", Price=2M },
        };
        
        public GetAllProductsQueryHandlerTests()
        {
            _productRepository = new Mock<IProductRepository>();
        }

        [Fact]
        public async void GetProducts_AllAvailableProductsAreReturned()
        {
            // Arrange
            _productRepository.Setup(s => s.GetProductsAsync(default)).ReturnsAsync(_products);
            var sut = new GetAllProductsQueryHandler(_productRepository.Object);
            
            // Act
            var products = await sut.Handle(new GetAllProductsQuery(), default);
            
            // Assert
            products.Should().BeEquivalentTo(_products);
        }
    }
}
