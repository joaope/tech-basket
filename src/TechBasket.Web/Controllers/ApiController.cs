using Microsoft.AspNetCore.Mvc;
using TechBasket.DomainService;
using TechBasket.Web.Models;

namespace TechBasket.Web.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        private readonly IProductService _productService;

        public ApiController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("products")]
        public GetProductsResponse GetProducts()
        {
            return new GetProductsResponse(_productService.GetProducts());
        }
    }
}