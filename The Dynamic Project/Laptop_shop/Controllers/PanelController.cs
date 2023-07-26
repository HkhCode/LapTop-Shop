using Laptop_shop.Models.Data;
using Laptop_shop.Utilities;
using Laptop_shop.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;

namespace Laptop_shop.Controllers
{
    public class PanelController : BaseController
    {
        public IActionResult Index()
        {
            int? userid = HttpContext.Session.GetInt32(UserSessionKey);
            if(userid == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                try
                {
                    int userId = (int)HttpContext.Session.GetInt32(UserSessionKey);
                    User user = UOW.UserRepo.Find(x => x.Id == userId).First();
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
                    UPVM.UserId = HttpContext.Session.GetInt32(UserSessionKey);
                    UPVM.pageTitle = "خانه";
                    UPVM.Name = user.Name;
                    UPVM.Family = user.Family;
                    UPVM.Email = user.Email;
                    UPVM.Phone = user.PhoneNumber;
                    return View(UPVM);
                }
                catch
                {
                    return Redirect("/Login/Index");
                }
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(UserSessionKey);
            return Redirect("/Login/Index");
        }
    }
}
