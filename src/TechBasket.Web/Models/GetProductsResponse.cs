using System.Collections.Generic;
using System.Linq;

namespace TechBasket.Web.Models
{
    public sealed class GetProductsResponse : List<GetProductsResponse.Product>
    {
        public GetProductsResponse(IEnumerable<Product> products)
            : base(products)
        {
        }

        public GetProductsResponse(IEnumerable<DomainService.Models.Product> domainProducts)
            : base(domainProducts?.Select(p => new Product(p)) ?? new Product[0])
        {
        }

        public sealed class Product
        {
            public string Name { get; }

            public int Identifier { get; }

            public decimal Price { get; }

            public Product(string name, int identifier, decimal price)
            {
                Name = name;
                Identifier = identifier;
                Price = price;
            }

            public Product(DomainService.Models.Product domainProduct)
            {
                Name = domainProduct.Name;
                Identifier = (int)domainProduct.Identifier;
                Price = domainProduct.Price;
            }
        }
    }
}