using Moq;
using TechBasket.DomainService;
using TechBasket.DomainService.Models;
using TechBasket.Web.Controllers;
using TechBasket.Web.Models;
using Xunit;

namespace TechBasket.Web.UnitTests
{
    public class ApiControllerTests
    {
        private readonly Mock<IProductService> _productServiceMock;
        private readonly Mock<IBasketCalculatorService> _basketCalculatorServiceMock;

        private readonly ApiController _apiController;

        public ApiControllerTests()
        {
            _productServiceMock = new Mock<IProductService>();
            _basketCalculatorServiceMock = new Mock<IBasketCalculatorService>();

            _apiController = new ApiController(
                _productServiceMock.Object,
                _basketCalculatorServiceMock.Object);
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
            Assert.Equal((int)ProductIdentifier.Milk, products[0].Identifier);
            Assert.Equal(12m, products[0].Price);
            Assert.Equal("Butter", products[1].Name);
            Assert.Equal((int)ProductIdentifier.Butter, products[1].Identifier);
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

        [Fact]
        public void ApiController_GetBasketTotal_ReturnsCalculatedPriceFromService()
        {
            _basketCalculatorServiceMock
                .Setup(b => b.GetTotal(It.IsAny<Basket>()))
                .Returns(13);
            var totalRequest = new GetBasketTotalRequest
            {
                SelectedProductsIdentifiers = new []{ 0, 1 }
            };

            var calculatedDiscount = _apiController.GetBasketTotal(totalRequest);

            Assert.Equal(13, calculatedDiscount);
        }

        [Fact]
        public void ApiController_GetBasketTotal_ReturnsTotalEvenWhenNoProductsSelected()
        {
            _basketCalculatorServiceMock
                .Setup(b => b.GetTotal(It.IsAny<Basket>()))
                .Returns(0);
            var totalRequest = new GetBasketTotalRequest();

            var calculatedDiscount = _apiController.GetBasketTotal(totalRequest);

            Assert.Equal(0, calculatedDiscount);
        }
    }
}
