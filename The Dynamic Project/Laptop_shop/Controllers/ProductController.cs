using Microsoft.AspNetCore.Mvc;

namespace Laptop_shop.Controllers
{
    public class ProductController : BaseController
    {
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
