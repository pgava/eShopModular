using System;
using System.Collections.Generic;
using System.Linq;
using eShopCmc.Application.Products;
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
            new Product( new ProductId(Guid.NewGuid()), "product1", "product1", "img1", 1M ),
            new Product( new ProductId(Guid.NewGuid()), "product2", "product2", "img2", 2M ),
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
            products.Should().BeEquivalentTo(GetProductsViewModel());
        }
        
        private List<ProductViewModel> GetProductsViewModel()
        {
            return _products.Select(p => new ProductViewModel
            (
                p.Id.Value,
                p.Name,
                p.Price,
                p.ImageUrl,
                p.Description
            )).ToList();
        }
    }
}
