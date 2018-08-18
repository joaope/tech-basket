using Moq;
using TechBasket.DomainService.Infrastructure;
using TechBasket.DomainService.Models;
using Xunit;

namespace TechBasket.DomainService.UnitTests
{
    public sealed class ProductServiceTests
    {
        [Fact]
        public void GetProducts_ReturnsAllProductsFromRepository_EmptyBecauseNoProductsExist()
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock
                .Setup(p => p.GetProducts())
                .Returns(() => null);
            var productService = new ProductService(productRepositoryMock.Object);

            var products = productService.GetProducts();

            Assert.Empty(products);
        }

        [Fact]
        public void GetProducts_ReturnsAllProductsFromRepository()
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock
                .Setup(p => p.GetProducts())
                .Returns(new[]
                {
                    new Product("Milk", ProductIdentifier.Milk, 12.3m),
                    new Product("Bread", ProductIdentifier.Bread, 2m)
                });
            var productService = new ProductService(productRepositoryMock.Object);

            var products = productService.GetProducts();

            Assert.Equal(2, products.Length);
            Assert.Equal("Milk", products[0].Name);
            Assert.Equal(ProductIdentifier.Milk, products[0].Identifier);
            Assert.Equal(12.3m, products[0].Price);
            Assert.Equal("Bread", products[1].Name);
            Assert.Equal(ProductIdentifier.Bread, products[1].Identifier);
            Assert.Equal(2m, products[1].Price);
        }
    }
}