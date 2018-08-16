using System.Linq;
using TechBasket.DomainService.Models;

namespace TechBasket.DomainService
{
    public sealed class TwoButtersGetBreadHalfPriceOffer : IOffer
    {
        public void Apply(PricedProduct[] products)
        {
            var totalDiscountedBreads = products.Count(p => p.Identifier == ProductIdentifier.Butter) / 2;

            foreach (var breadToDiscount in products
                .Where(p => p.Identifier == ProductIdentifier.Bread)
                .Take(totalDiscountedBreads))
            {
                breadToDiscount.SetDiscountedPrice(breadToDiscount.InitialPrice * 0.5m);
            }
        }
    }
}