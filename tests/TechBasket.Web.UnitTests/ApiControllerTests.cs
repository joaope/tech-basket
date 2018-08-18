using Moq;
using TechBasket.DomainService;
using TechBasket.DomainService.Models;
using TechBasket.Web.Controllers;
using Xunit;

namespace TechBasket.Web.UnitTests
{
    public class ApiControllerTests
    {
        private readonly Mock<IProductService> _productServiceMock;
        private readonly ApiController _apiController;

        public ApiControllerTests()
        {
            _productServiceMock = new Mock<IProductService>();
            _apiController = new ApiController(_productServiceMock.Object);
        }

        [Fact]
        public void ApiController_GetProducts_ReturnProductsFromDomainService()
        {
            _productServiceMock
                .Setup(s => s.GetProducts())
                .Returns(new[]
                {
                    new Product("Milk", ProductIdentifier.Milk, 12m),
                    new Product("Butter", ProductIdentifier.Butter, 0.5m)
                });

            var products = _apiController.GetProducts();

            Assert.Equal(2, products.Count);
            Assert.Equal("Milk", products[0].Name);
            Assert.Equal("Milk", products[0].Identifier);
            Assert.Equal(12m, products[0].Price);
            Assert.Equal("Butter", products[1].Name);
            Assert.Equal("Butter", products[1].Identifier);
            Assert.Equal(0.5m, products[1].Price);
        }

        [Fact]
        public void ApiController_GetProducts_ReturnsEmptyProducts()
        {
            _productServiceMock
                .Setup(s => s.GetProducts())
                .Returns(() => null);

            var products = _apiController.GetProducts();

            Assert.Empty(products);
        }
    }
}
