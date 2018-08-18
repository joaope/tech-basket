using System.Collections.Generic;
using System.Linq;
using TechBasket.DomainService.Models;

namespace TechBasket.DomainService.Infrastructure
{
    public sealed class InMemoryProductRepository : IProductRepository
    {
        private static readonly IReadOnlyCollection<ProductModel> Products = new[]
        {
            new ProductModel("Milk", ProductIdentifier.Milk, 1.15m),
            new ProductModel("Bread", ProductIdentifier.Bread, 1m),
            new ProductModel("Butter", ProductIdentifier.Butter, 0.8m)
        };

        public IDictionary<ProductIdentifier, decimal> GetProductsPrices()
        {
            return Products.ToDictionary(p => p.Identifier, p => p.Price);
        }

        public Product[] GetProducts()
        {
            return Products
                .Select(p => new Product(p.Name, p.Identifier, p.Price))
                .ToArray();
        }

        private sealed class ProductModel
        {
            public string Name { get; }

            public ProductIdentifier Identifier { get; }

            public decimal Price { get; }

            public ProductModel(string name, ProductIdentifier identifier, decimal price)
            {
                Name = name;
                Identifier = identifier;
                Price = price;
            }
        }
    }
}