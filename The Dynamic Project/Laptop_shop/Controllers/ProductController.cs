using Microsoft.AspNetCore.Mvc;

namespace Laptop_shop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
