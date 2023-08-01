using Laptop_shop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Laptop_shop.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            try
            {
                int id = (int)HttpContext.Session.GetInt32(UserSessionKey);
                if(AdminAuthorize(id))
                {
                    AdminSideLayoutModel model = new AdminSideLayoutModel();
                    model.Title = "پنل مدیریت";
                    return View(model);
                }
                else
                {
                    return Redirect("/Login/Index");
                }
            }
            catch
            {
                return Redirect("/Login/Index");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(UserSessionKey);
            return Redirect("/Login/Index");
        }
    }
}
