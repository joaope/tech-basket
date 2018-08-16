using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TechBasket.DomainService.Models;

namespace TechBasket.DomainService
{
    public class BasketCalculatorService
    {
        private static readonly IDictionary<ProductIdentifier, decimal> ProductPrices = new Dictionary<ProductIdentifier, decimal>
        {
            { ProductIdentifier.Milk, 1.15m },
            { ProductIdentifier.Bread, 1m },
            { ProductIdentifier.Butter, 0.8m }
        };

        public decimal GetTotal(Basket basket)
        {
            if (basket?.Products == null ||
                basket.Products.Length == 0)
            {
                return 0;
            }

            return basket.Products.Sum(p => ProductPrices[p]);
        }
    }
}