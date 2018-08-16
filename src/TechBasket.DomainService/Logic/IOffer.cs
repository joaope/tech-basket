using TechBasket.DomainService.Models;

namespace TechBasket.DomainService.Logic
{
    public interface IOffer
    {
        void Apply(PricedProduct[] products);
    }
}