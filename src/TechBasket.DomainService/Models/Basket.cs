using System.Collections.Generic;
using System.Linq;

namespace TechBasket.DomainService.Models
{
    public class Basket
    {
        private ProductIdentifier[] Products { get; }

        public Basket(IEnumerable<ProductIdentifier> products)
        {
            Products = products?.ToArray() ?? new ProductIdentifier[0];
        }
    }
}