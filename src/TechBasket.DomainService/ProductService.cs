using TechBasket.DomainService.Infrastructure;
using TechBasket.DomainService.Models;

namespace TechBasket.DomainService
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public Product[] GetProducts()
        {
            return _productRepository.GetProducts() ?? new Product[0];
        }
    }
}