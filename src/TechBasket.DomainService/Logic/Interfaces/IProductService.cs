using TechBasket.DomainService.Models;

namespace TechBasket.DomainService
{
    public interface IProductService
    {
        Product[] GetProducts();
    }
}