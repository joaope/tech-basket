using System.Collections.Generic;
using TechBasket.DomainService.Models;

namespace TechBasket.DomainService.Infrastructure
{
    public interface IProductRepository
    {
        IDictionary<ProductIdentifier, decimal> GetProductsPrices();
    }
}