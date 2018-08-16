using System.Collections.Generic;
using Moq;
using TechBasket.DomainService.Infrastructure;
using TechBasket.DomainService.Models;
using Xunit;

namespace TechBasket.DomainService.UnitTests
{
    public class BasketCalculatorServiceTests
    {
        private readonly BasketCalculatorService _calculatorService;

        public BasketCalculatorServiceTests()
        {
            var productRepositoryMock = new Mock<IProductRepository>();

            productRepositoryMock
                .Setup(r => r.GetProductsPrices())
                .Returns(new Dictionary<ProductIdentifier, decimal>
                {
                    {ProductIdentifier.Milk, 1.15m},
                    {ProductIdentifier.Bread, 1m},
                    {ProductIdentifier.Butter, 0.8m}
                });

            _calculatorService = new BasketCalculatorService(productRepositoryMock.Object);
        }

        [Theory]
        [MemberData(nameof(GetTotalTestsData))]
        public void GetTotal_TestsDifferentBasketsAndOffers_ReturnsTotalWithDiscounts(decimal expectedTotal, Basket basket)
        {
            var total = _calculatorService.GetTotal(basket);

            Assert.Equal(expectedTotal, total);
        }

        public static IEnumerable<object[]> GetTotalTestsData()
        {
            yield return new object[]
            {
                0,
                new Basket(new ProductIdentifier[0])
            };

            yield return new object[]
            {
                0,
                new Basket(null)
            };

            yield return new object[]
            {
                2.95m,
                new Basket(new []
                {
                    ProductIdentifier.Bread,
                    ProductIdentifier.Butter,
                    ProductIdentifier.Milk
                })
            };

            yield return new object[]
            {
                3.10m,
                new Basket(new []
                {
                    ProductIdentifier.Butter,
                    ProductIdentifier.Butter,
                    ProductIdentifier.Bread,
                    ProductIdentifier.Bread
                })
            };

            yield return new object[]
            {
                4.20m,
                new Basket(new []
                {
                    ProductIdentifier.Butter,
                    ProductIdentifier.Butter,
                    ProductIdentifier.Butter,
                    ProductIdentifier.Butter,
                    ProductIdentifier.Bread,
                    ProductIdentifier.Bread
                })
            };

            yield return new object[]
            {
                3.45m,
                new Basket(new []
                {
                    ProductIdentifier.Milk,
                    ProductIdentifier.Milk,
                    ProductIdentifier.Milk,
                    ProductIdentifier.Milk
                })
            };

            yield return new object[]
            {
                9m,
                new Basket(new []
                {
                    ProductIdentifier.Butter,
                    ProductIdentifier.Butter,
                    ProductIdentifier.Bread,
                    ProductIdentifier.Milk,
                    ProductIdentifier.Milk,
                    ProductIdentifier.Milk,
                    ProductIdentifier.Milk,
                    ProductIdentifier.Milk,
                    ProductIdentifier.Milk,
                    ProductIdentifier.Milk,
                    ProductIdentifier.Milk
                })
            };
        }
    }
}
