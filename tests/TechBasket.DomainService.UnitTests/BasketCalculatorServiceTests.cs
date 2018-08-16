using TechBasket.DomainService.Models;
using Xunit;

namespace TechBasket.DomainService.UnitTests
{
    public class BasketCalculatorServiceTests
    {
        [Fact]
        public void GetTotal_AllProducts_NoOffers()
        {
            var basket = new Basket(new ProductIdentifier[0]);
            var calculatorService = new BasketCalculatorService();

            var total = calculatorService.GetTotal(basket);

            Assert.Equal(0, total);
        }
    }
}
