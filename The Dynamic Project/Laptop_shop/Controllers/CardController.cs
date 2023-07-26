using Laptop_shop.Models.Data;
using Laptop_shop.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;
using Laptop_shop.ViewModels.PreQuesties;
using Laptop_shop.Utilities;

namespace Laptop_shop.Controllers
{
    public class CardController : BaseController
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32(UserSessionKey) == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                int userId = (int)HttpContext.Session.GetInt32(UserSessionKey);
                Card card = UOW.CardRepo.Find(x => x.UserId == userId).First();
                CardViewModel CVM = new CardViewModel();
                List<Adds> adds = UOW.AddsRepo.GetAll().ToList();
                Slider slider = UOW.SliderRepo.GetAll().ToList()[0];
                CVM.Adds1Data = ImageAndBytesHandler.ByteArrayToImage(adds[0].ImageData);
                CVM.Adds2Data = ImageAndBytesHandler.ByteArrayToImage(adds[1].ImageData);
                CVM.sliderImage1Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image1Data);
                CVM.Description1 = slider.Description1;
                CVM.Title1 = slider.Title1;
                CVM.sliderImage2Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image2Data);
                CVM.Description2 = slider.Description2;
                CVM.Title2 = slider.Title2;
                CVM.sliderImage3Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image3Data);
                CVM.Description3 = slider.Description3;
                CVM.Title3 = slider.Title3;
                ShopInfo shopInfo = UOW.ShopInfoRepo.GetAll().ToList()[0];
                CVM.ShopPhone = shopInfo.ShopPhone;
                CVM.ShopEmail = shopInfo.ShopEmail;
                CVM.UserId = HttpContext.Session.GetInt32(UserSessionKey);
                CVM.pageTitle = "سبد خرید";
                card.Products.Add(UOW.ProductRepo.GetAll().ToList()[0]);
                int TotalPrice = 0;
                foreach(Product product in card.Products)
                {
                    UserSideProduct USP = new UserSideProduct() {
                        Id = product.Id,
                        Title = product.Title,
                        Price = product.Price
                    };
                    CVM.Products.Append(USP);
                    TotalPrice += product.Price;
                }
                CVM.FullPrice = TotalPrice;
                return View(CVM);
            }
        }
        public IActionResult DeleteProduct(int id)
        {
            int userId = (int)HttpContext.Session.GetInt32(UserSessionKey);
            Card card = UOW.CardRepo.Find(x => x.UserId == userId).First();
            Product product = card.Products.Where(x => x.Id == id).FirstOrDefault();
            card.Products.Remove(product);
            UOW.CardRepo.Update(card);
            return Redirect("/Card/Index");
        }
    }
}
