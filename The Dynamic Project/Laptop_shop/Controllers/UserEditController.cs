using Laptop_shop.Models.Data;
using Laptop_shop.Utilities;
using Laptop_shop.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;

namespace Laptop_shop.Controllers
{
    public class UserEditController : BaseController
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32(UserSessionKey)!=null)
            {
                UserEditViewModel UEVM = new UserEditViewModel();
                List<Adds> adds = UOW.AddsRepo.GetAll().ToList();
                Slider slider = UOW.SliderRepo.GetAll().ToList()[0];
                UEVM.Adds1Data = ImageAndBytesHandler.ByteArrayToImage(adds[0].ImageData);
                UEVM.Adds2Data = ImageAndBytesHandler.ByteArrayToImage(adds[1].ImageData);
                UEVM.sliderImage1Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image1Data);
                UEVM.Description1 = slider.Description1;
                UEVM.Title1 = slider.Title1;
                UEVM.sliderImage2Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image2Data);
                UEVM.Description2 = slider.Description2;
                UEVM.Title2 = slider.Title2;
                UEVM.sliderImage3Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image3Data);
                UEVM.Description3 = slider.Description3;
                UEVM.Title3 = slider.Title3;
                ShopInfo shopInfo = UOW.ShopInfoRepo.GetAll().ToList()[0];
                UEVM.ShopPhone = shopInfo.ShopPhone;
                UEVM.ShopEmail = shopInfo.ShopEmail;
                UEVM.UserId = HttpContext.Session.GetInt32(UserSessionKey);
                UEVM.pageTitle = "ویرایش اطلاعات کاربری";
                return View(UEVM);
            }
            else
            {
                return Redirect("/Login/Index");
            }
        }
        [HttpPost]
        public IActionResult Index(UserEditViewModel UEVM)
        {
            if(UEVM.Password == UEVM.RepeatPassword)
            {
                    User user = new User()
                    {
                        Name = UEVM.Name,
                        Family = UEVM.Family,
                        Email = UEVM.Email,
                        PhoneNumber = UEVM.Phone,
                        Password = UEVM.Password
                    };
                int userId = (int)HttpContext.Session.GetInt32(UserSessionKey);
                UOW.UserRepo.Delete(userId);
                UOW.UserRepo.Insert(user);
                int NewId = UOW.UserRepo.Find(x => x.Email == user.Email).First().Id;
                HttpContext.Session.Remove(UserSessionKey);
                HttpContext.Session.SetInt32(UserSessionKey, NewId);
                return Redirect("/Panel/Index");
            }
            else
            {
                UserEditViewModel uevm = new UserEditViewModel();
                List<Adds> adds = UOW.AddsRepo.GetAll().ToList();
                Slider slider = UOW.SliderRepo.GetAll().ToList()[0];
                uevm.Adds1Data = ImageAndBytesHandler.ByteArrayToImage(adds[0].ImageData);
                uevm.Adds2Data = ImageAndBytesHandler.ByteArrayToImage(adds[1].ImageData);
                uevm.sliderImage1Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image1Data);
                uevm.Description1 = slider.Description1;
                uevm.Title1 = slider.Title1;
                uevm.sliderImage2Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image2Data);
                uevm.Description2 = slider.Description2;
                uevm.Title2 = slider.Title2;
                uevm.sliderImage3Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image3Data);
                uevm.Description3 = slider.Description3;
                uevm.Title3 = slider.Title3;
                ShopInfo shopInfo = UOW.ShopInfoRepo.GetAll().ToList()[0];
                uevm.ShopPhone = shopInfo.ShopPhone;
                uevm.ShopEmail = shopInfo.ShopEmail;
                uevm.UserId = HttpContext.Session.GetInt32(UserSessionKey);
                uevm.pageTitle = "ویرایش اطلاعات کاربری";
                uevm.Message = "کلمه عبور و تکرار کلمه عبور باید باهم یکسان باشند!";
                return View(uevm);
            }
        }
    }
}
