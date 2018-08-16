using System.Collections.Generic;
using TechBasket.DomainService.Models;

namespace TechBasket.DomainService.Infrastructure
{
    public interface IProductRepository
    {
        IDictionary<ProductIdentifier, decimal> GetProductsPrices();
    }

    public sealed class InMemoryProductRepository : IProductRepository
    {
        private static readonly IDictionary<ProductIdentifier, decimal> ProductPrices = new Dictionary<ProductIdentifier, decimal>
        {
            { ProductIdentifier.Milk, 1.15m },
            { ProductIdentifier.Bread, 1m },
            { ProductIdentifier.Butter, 0.8m }
        };

        public IDictionary<ProductIdentifier, decimal> GetProductsPrices()
        {
            return ProductPrices;
        }
    }
}