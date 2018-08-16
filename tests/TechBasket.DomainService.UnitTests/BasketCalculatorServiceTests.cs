using TechBasket.DomainService.Models;
using Xunit;

namespace TechBasket.DomainService.UnitTests
{
    public class BasketCalculatorServiceTests
    {
        private readonly BasketCalculatorService _calculatorService = new BasketCalculatorService();

        [Fact]
        public void GetTotal_NoProductNoOffers_TotalZero()
        {
            var basket = new Basket(new ProductIdentifier[0]);

            var total = _calculatorService.GetTotal(basket);

            Assert.Equal(0, total);
        }

        [Fact]
        public void GetTotal_AllProducts_NoOffers()
        {
            var basket = new Basket(new []
            {
                ProductIdentifier.Bread,
                ProductIdentifier.Butter,
                ProductIdentifier.Milk
            });

            var total = _calculatorService.GetTotal(basket);

            Assert.Equal(2.95m, total);
        }
    }
}
