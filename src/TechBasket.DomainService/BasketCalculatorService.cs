using System.Linq;
using TechBasket.DomainService.Infrastructure;
using TechBasket.DomainService.Logic;
using TechBasket.DomainService.Models;

namespace TechBasket.DomainService
{
    public class BasketCalculatorService
    {
        private readonly IProductRepository _productRepository;

        public BasketCalculatorService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public decimal GetTotal(Basket basket)
        {
            if (basket?.Products == null ||
                basket.Products.Length == 0)
            {
                return 0;
            }

            var currentProductPrices = _productRepository.GetProductsPrices();

            var productsWithPrices = basket
                .Products
                .Select(p => new PricedProduct(p, currentProductPrices[p]))
                .ToArray();

            new TwoButtersGetBreadHalfPriceOffer().Apply(productsWithPrices);
            new ThreeMilkFourthFreeOffer().Apply(productsWithPrices);

            return productsWithPrices.Sum(p => p.DiscountedPrice);
        }
    }
}