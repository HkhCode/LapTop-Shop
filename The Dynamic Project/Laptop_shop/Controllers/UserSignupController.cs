using Laptop_shop.Models.Data;
using Laptop_shop.Models.Enums;
using Laptop_shop.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;

namespace Laptop_shop.Controllers
{
    public class UserSignupController : BaseController
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32(UserSessionKey) != null)
            {
                return Redirect("/Panel/Index");
            }
            SignupViewModel SVM = new SignupViewModel();
            return View(SVM);
        }
        [HttpPost]
        public IActionResult Index(SignupViewModel SVM)
        {
            try
            {
                User user = UOW.UserRepo.Find(x => x.Email == SVM.Email).First();
                SignupViewModel svm = new SignupViewModel();
                svm.Message = "این ایمیل قبلا ثبت نام کرده است";
                return View(svm);
            }
            catch
            {
                if(SVM.Password == SVM.PasswordRepeat)
                {
                    if(SVM.Password.Length < 8)
                    {
                        SignupViewModel svm = new SignupViewModel();
                        svm.Message = "طول کلمه ی عبور باید حداقل 8 کارکتر باشد!";
                        return View(svm);
                    }
                    else
                    {
                        if(SVM.AcceptRules)
                        {
                            User user = new User();
                            user.Email = SVM.Email;
                            user.Password = SVM.Password;
                            user.Name = SVM.Name;
                            user.Family = SVM.Family;
                            user.PhoneNumber = SVM.Phone;
                            user.Role = Role.User;
                            UOW.UserRepo.Insert(user);
                            int UserId = UOW.UserRepo.Find(x => x.Email == user.Email).First().Id;
                            HttpContext.Session.SetInt32(UserSessionKey, UserId);
                            return Redirect("/Panel/Index");
                        }
                        else
                        {
                            SignupViewModel svm = new SignupViewModel();
                            svm.Message = "لطفا گزینه ی موافقت با قوانین را فعال کنید!";
                            return View(svm);
                        }
                    }

                }
                else
                {
                    SignupViewModel svm = new SignupViewModel();
                    svm.Message = "کلمه عبور و تکرار کلمه عبور یکسان نیستند!";
                    return View(svm);
                }

            }
        }
    }
}
