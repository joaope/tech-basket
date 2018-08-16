using System.Linq;
using TechBasket.DomainService.Models;

namespace TechBasket.DomainService.Logic
{
    public sealed class ThreeMilkFourthFreeOffer : IOffer
    {
        public void Apply(PricedProduct[] products)
        {
            var totalMilksToDiscount = products.Count(p => p.Identifier == ProductIdentifier.Milk) / 4;

            foreach (var breadToDiscount in products
                .Where(p => p.Identifier == ProductIdentifier.Milk)
                .Take(totalMilksToDiscount))
            {
                breadToDiscount.SetDiscountedPrice(0);
            }
        }
    }
}