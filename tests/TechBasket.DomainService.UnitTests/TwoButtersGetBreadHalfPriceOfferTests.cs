using System.Linq;
using TechBasket.DomainService.Logic;
using TechBasket.DomainService.Models;
using Xunit;

namespace TechBasket.DomainService.UnitTests
{
    public sealed class TwoButtersGetBreadHalfPriceOfferTests
    {
        private readonly IOffer _offer = new TwoButtersGetBreadHalfPriceOffer();

        [Fact]
        public void ApplyDiscount_TwoButters_ApplyDiscountToOneBread()
        {
            var pricedProducts = new[]
            {
                new PricedProduct(ProductIdentifier.Butter, 0.8m),
                new PricedProduct(ProductIdentifier.Butter, 0.8m),
                new PricedProduct(ProductIdentifier.Bread, 1m),
                new PricedProduct(ProductIdentifier.Bread, 1m)
            };

            _offer.Apply(pricedProducts);

            Assert.Equal(4, pricedProducts.Length);
            Assert.True(pricedProducts.All(p => p.Identifier == ProductIdentifier.Bread || p.Identifier == ProductIdentifier.Butter));
            Assert.Equal(1, pricedProducts.Count(p => p.Identifier == ProductIdentifier.Bread && p.DiscountedPrice == 0.5m));
            Assert.Equal(1, pricedProducts.Count(p => p.Identifier == ProductIdentifier.Bread && p.DiscountedPrice == 1));
            Assert.Equal(2, pricedProducts.Count(p => p.Identifier == ProductIdentifier.Butter && p.DiscountedPrice == 0.8m));
        }
    }
}
