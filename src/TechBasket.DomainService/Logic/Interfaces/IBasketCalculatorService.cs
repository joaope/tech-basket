using TechBasket.DomainService.Models;

namespace TechBasket.DomainService
{
    public interface IBasketCalculatorService
    {
        decimal GetTotal(Basket basket);
    }
}