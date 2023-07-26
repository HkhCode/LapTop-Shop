using Microsoft.AspNetCore.Mvc;

namespace Laptop_shop.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
