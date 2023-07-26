using Laptop_shop.Models.Data;
using Laptop_shop.Models.Enums;
using Laptop_shop.Utilities;
using Laptop_shop.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;

namespace Laptop_shop.Controllers
{
    public class LoginController : BaseController
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32(UserSessionKey) != null)
            {
                return Redirect("/Panel/Index");
            }
            else
            {
                LoginViewModel lvm = new LoginViewModel();
                return View("Login", lvm);
            }

        }
        [HttpPost]
        public IActionResult Index(LoginViewModel LVM)
        {
            try
            {
                User user = UOW.UserRepo.Find(x=> x.Email == LVM.Email).First();
                if(user.Password == LVM.Password)
                {
                    HttpContext.Session.SetInt32(UserSessionKey, user.Id);
                    if(user.Role == Role.User)
                    {
                        return Redirect("/Panel/Index");
                    }
                    else
                    {
                        return Redirect("/Admin/Index");
                    }
                }
                else
                {
                    LoginViewModel lvm = new LoginViewModel();
                    lvm.Message = "کلمه عبور اشتباه است";
                    return View("Login",lvm);
                }
            }
            catch(Exception ex)
            {
                LoginViewModel lvm = new LoginViewModel();
                lvm.Message = "ایمیل مورد نطر پیدا نشد";
                return View("Login" , lvm);
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(UserSessionKey);
            return Redirect("/LoginAndSignup/Login");
        }
    }
}
