using Microsoft.AspNetCore.Mvc;

namespace TechBasket.Web.Controllers
{
    public class WebController : Controller
    {
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }
    }
}
