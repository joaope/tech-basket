using TechBasket.DomainService.Models;

namespace TechBasket.DomainService
{
    public interface IOffer
    {
        void Apply(PricedProduct[] products);
    }
}