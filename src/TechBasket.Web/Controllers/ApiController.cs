using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechBasket.DomainService;
using TechBasket.DomainService.Models;
using TechBasket.Web.Models;

namespace TechBasket.Web.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketCalculatorService _basketCalculatorService;

        public ApiController(
            IProductService productService,
            IBasketCalculatorService basketCalculatorService)
        {
            _productService = productService;
            _basketCalculatorService = basketCalculatorService;
        }

        [HttpGet]
        [Route("products")]
        public GetProductsResponse GetProducts()
        {
            return new GetProductsResponse(_productService.GetProducts());
        }

        [HttpPost]
        [Route("basket-total")]
        public decimal GetBasketTotal([FromBody]GetBasketTotalRequest totalRequest)
        {
            var basket = new Basket(
                totalRequest
                .SelectedProductsIdentifiers
                .Select(i => (ProductIdentifier)i));

            return _basketCalculatorService.GetTotal(basket);
        }
    }
}