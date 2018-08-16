using TechBasket.DomainService.Logic;

namespace TechBasket.DomainService.Infrastructure
{
    public sealed class InMemoryOfferRepository : IOfferRepository
    {
        private static readonly IOffer[] Offers = {
            new TwoButtersGetBreadHalfPriceOffer(),
            new ThreeMilkFourthFreeOffer()
        };

        public IOffer[] GetAll()
        {
            return Offers;
        }
    }
}