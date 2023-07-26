using Laptop_shop.Models.Data;
using Laptop_shop.Utilities;
using Laptop_shop.ViewModels.Pages;
using Laptop_shop.ViewModels.PreQuesties;
using Microsoft.AspNetCore.Mvc;

namespace Laptop_shop.Controllers
{
    public class SearchController : BaseController
    {
        public IActionResult Index()
        {
            SearchViewModel SVM = new SearchViewModel();
            List<Adds> adds = UOW.AddsRepo.GetAll().ToList();
            Slider slider = UOW.SliderRepo.GetAll().ToList()[0];
            SVM.Adds1Data = ImageAndBytesHandler.ByteArrayToImage(adds[0].ImageData);
            SVM.Adds2Data = ImageAndBytesHandler.ByteArrayToImage(adds[1].ImageData);
            SVM.sliderImage1Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image1Data);
            SVM.Description1 = slider.Description1;
            SVM.Title1 = slider.Title1;
            SVM.sliderImage2Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image2Data);
            SVM.Description2 = slider.Description2;
            SVM.Title2 = slider.Title2;
            SVM.sliderImage3Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image3Data);
            SVM.Description3 = slider.Description3;
            SVM.Title3 = slider.Title3;
            ShopInfo shopInfo = UOW.ShopInfoRepo.GetAll().ToList()[0];
            SVM.ShopPhone = shopInfo.ShopPhone;
            SVM.ShopEmail = shopInfo.ShopEmail;
            SVM.UserId = HttpContext.Session.GetInt32(UserSessionKey);
            SVM.pageTitle = "جست و جو";
            return View(SVM);
        }
        [HttpPost]
        public IActionResult Index(SearchViewModel SVM)
        {
            List<SearchPageProducts> SelectedProducts = new List<SearchPageProducts>();
            List<Product> products = UOW.ProductRepo.Find(x => x.Title.Replace(" ", "") == SVM.SearchExpression.Replace(" ","")).ToList();
            foreach (Product product in products)
            {
                SelectedProducts.Append(new SearchPageProducts()
                {
                    ProductTitle = product.Title,
                    ProductDescription = product.Description,
                    Id = product.Id,
                    ProductImage = ImageAndBytesHandler.ByteArrayToImage(product.Image1Data)
                 });
            }
            SVM.searchPageProducts = SelectedProducts;
            return View(SVM);
        }
    }
}
