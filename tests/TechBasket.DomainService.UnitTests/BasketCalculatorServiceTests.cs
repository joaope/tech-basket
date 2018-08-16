using System.Collections.Generic;
using TechBasket.DomainService.Models;
using Xunit;

namespace TechBasket.DomainService.UnitTests
{
    public class BasketCalculatorServiceTests
    {
        private readonly BasketCalculatorService _calculatorService = new BasketCalculatorService();

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
                2.95m,
                new Basket(new []
                {
                    ProductIdentifier.Bread,
                    ProductIdentifier.Butter,
                    ProductIdentifier.Milk
                })
            };
        }
    }
}
