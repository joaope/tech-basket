using System.Linq;
using TechBasket.DomainService.Infrastructure;
using TechBasket.DomainService.Models;

namespace TechBasket.DomainService
{
    public sealed class BasketCalculatorService : IBasketCalculatorService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IProductRepository _productRepository;

        public BasketCalculatorService(
            IOfferRepository offerRepository,
            IProductRepository productRepository)
        {
            _offerRepository = offerRepository;
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

            var offers = _offerRepository.GetAll();

            foreach (var offer in offers)
            {
                offer.Apply(productsWithPrices);
            }
            
            return productsWithPrices.Sum(p => p.DiscountedPrice);
        }
    }
}