using System.Linq;
using TechBasket.DomainService.Logic;
using TechBasket.DomainService.Models;
using Xunit;

namespace TechBasket.DomainService.UnitTests
{
    public sealed class ThreeMilkFourthFreeOfferTests
    {
        private readonly IOffer _offer = new ThreeMilkFourthFreeOffer();

        [Fact]
        public void ApplyDiscount_FourMilk_OneFree()
        {
            var pricedProducts = new[]
            {
                new PricedProduct(ProductIdentifier.Milk, 1.15m),
                new PricedProduct(ProductIdentifier.Milk, 1.15m),
                new PricedProduct(ProductIdentifier.Milk, 1.15m),
                new PricedProduct(ProductIdentifier.Milk, 1.15m)
            };

            _offer.Apply(pricedProducts);

            Assert.Equal(4, pricedProducts.Length);
            Assert.True(pricedProducts.All(p => p.Identifier == ProductIdentifier.Milk));
            Assert.Equal(1, pricedProducts.Count(p => p.DiscountedPrice == 0));
            Assert.Equal(3, pricedProducts.Count(p => p.DiscountedPrice == 1.15m));
        }

        [Fact]
        public void ApplyDiscount_EightMilk_TwoFree()
        {
            var pricedProducts = new[]
            {
                new PricedProduct(ProductIdentifier.Milk, 1.15m),
                new PricedProduct(ProductIdentifier.Milk, 1.15m),
                new PricedProduct(ProductIdentifier.Milk, 1.15m),
                new PricedProduct(ProductIdentifier.Milk, 1.15m),
                new PricedProduct(ProductIdentifier.Milk, 1.15m),
                new PricedProduct(ProductIdentifier.Milk, 1.15m),
                new PricedProduct(ProductIdentifier.Milk, 1.15m),
                new PricedProduct(ProductIdentifier.Milk, 1.15m)
            };

            _offer.Apply(pricedProducts);

            Assert.Equal(8, pricedProducts.Length);
            Assert.True(pricedProducts.All(p => p.Identifier == ProductIdentifier.Milk));
            Assert.Equal(2, pricedProducts.Count(p => p.DiscountedPrice == 0));
            Assert.Equal(6, pricedProducts.Count(p => p.DiscountedPrice == 1.15m));
        }
    }
}
