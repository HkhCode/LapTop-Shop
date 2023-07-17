using Laptop_shop.Models.Data;
using Laptop_shop.Utilities;
using Laptop_shop.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;

namespace Laptop_shop.Controllers
{
    public class LoginAndSignup : BaseController
    {
        public IActionResult Login()
        {
            LoginViewModel LVM = new LoginViewModel();
            int? userid = HttpContext.Session.GetInt32(UserSessionKey);
            if (userid == null)
            {
                return View(LVM);
            }
            else
            {
                UserPanelViewModel UPVM = new UserPanelViewModel();
                List<Adds> adds = UOW.AddsRepo.GetAll().ToList();
                Slider slider = UOW.SliderRepo.GetAll().ToList()[0];
                UPVM.Adds1Data = ImageAndBytesHandler.ByteArrayToImage(adds[0].ImageData);
                UPVM.Adds2Data = ImageAndBytesHandler.ByteArrayToImage(adds[1].ImageData);
                UPVM.sliderImage1Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image1Data);
                UPVM.Description1 = slider.Description1;
                UPVM.Title1 = slider.Title1;
                UPVM.sliderImage2Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image2Data);
                UPVM.Description2 = slider.Description2;
                UPVM.Title2 = slider.Title2;
                UPVM.sliderImage3Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image3Data);
                UPVM.Description3 = slider.Description3;
                UPVM.Title3 = slider.Title3;
                ShopInfo shopInfo = UOW.ShopInfoRepo.GetAll().ToList()[0];
                UPVM.ShopPhone = shopInfo.ShopPhone;
                UPVM.ShopEmail = shopInfo.ShopEmail;
                UPVM.Username = null;
                UPVM.pageTitle = "ناحیه کاربری";
                User user;
                try
                {
                    user = UOW.UserRepo.Find(x => x.Id == userid).First();
                }
                catch (Exception ex)
                {
                    LVM.Message = "مشکلی پیش آمد لطفا دوباره وارد شوید";
                    return View("Login", LVM);
                }
                UPVM.Email = user.Email;
                UPVM.Family = user.Family;
                UPVM.Name = user.Name;
                UPVM.UserId = user.Id;
                UPVM.Phone = user.PhoneNumber;
                return View("UserPanel", UPVM);
            }

        }
        [HttpPost]
        public IActionResult Login(LoginViewModel LVM)
        {
            UserPanelViewModel UPVM = new UserPanelViewModel();
            List<Adds> adds = UOW.AddsRepo.GetAll().ToList();
            Slider slider = UOW.SliderRepo.GetAll().ToList()[0];
            UPVM.Adds1Data = ImageAndBytesHandler.ByteArrayToImage(adds[0].ImageData);
            UPVM.Adds2Data = ImageAndBytesHandler.ByteArrayToImage(adds[1].ImageData);
            UPVM.sliderImage1Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image1Data);
            UPVM.Description1 = slider.Description1;
            UPVM.Title1 = slider.Title1;
            UPVM.sliderImage2Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image2Data);
            UPVM.Description2 = slider.Description2;
            UPVM.Title2 = slider.Title2;
            UPVM.sliderImage3Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image3Data);
            UPVM.Description3 = slider.Description3;
            UPVM.Title3 = slider.Title3;
            ShopInfo shopInfo = UOW.ShopInfoRepo.GetAll().ToList()[0];
            UPVM.ShopPhone = shopInfo.ShopPhone;
            UPVM.ShopEmail = shopInfo.ShopEmail;
            UPVM.Username = null;
            UPVM.pageTitle = "ناحیه کاربری";
            try
            {
                User user = UOW.UserRepo.Find(x => x.Email == LVM.Email).First();
                if (LVM.Password == user.Password)
                {
                    HttpContext.Session.SetInt32(UserSessionKey, user.Id);
                }
                UPVM.Email = user.Email;
                UPVM.Family = user.Family;
                UPVM.Name = user.Name;
                UPVM.UserId = user.Id;
                UPVM.Phone = user.PhoneNumber;
                return View("UserPanel", UPVM);
            }
            catch (Exception ex)
            {
                LVM.Message = "ایمیل وارد شده یافت نشد";
                return View("Login", LVM);
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(UserSessionKey);
            return View("Login" , new LoginViewModel());
        }
    }
}
