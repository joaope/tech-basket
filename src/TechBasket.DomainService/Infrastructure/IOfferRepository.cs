using TechBasket.DomainService.Logic;

namespace TechBasket.DomainService.Infrastructure
{
    public interface IOfferRepository
    {
        IOffer[] GetAll();
    }
}