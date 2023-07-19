using Laptop_shop.Models.Data;
using Laptop_shop.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;

namespace Laptop_shop.Controllers
{
    public class UserSignupController : BaseController
    {
        public IActionResult Index()
        {
            SignupViewModel SVM = new SignupViewModel();
            return View(SVM);
        }
        [HttpPost]
        public IActionResult Index(SignupViewModel SVM)
        {
            return View();
        }
    }
}
