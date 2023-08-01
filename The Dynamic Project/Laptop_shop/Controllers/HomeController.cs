using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Laptop_shop.Models;
using Laptop_shop.Models.Data;
using Laptop_shop.ViewModels.Pages;
using Laptop_shop.Utilities;

namespace Laptop_shop.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;

    }

    public IActionResult Index()
    {
        HomeViewModel HVM = new HomeViewModel();
        List<Adds> adds = UOW.AddsRepo.GetAll().ToList();
        Slider slider = UOW.SliderRepo.GetAll().ToList()[0];
        HVM.Adds1Data = ImageAndBytesHandler.ByteArrayToImage(adds[0].ImageData);
        HVM.Adds2Data = ImageAndBytesHandler.ByteArrayToImage(adds[1].ImageData);
        HVM.sliderImage1Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image1Data);
        HVM.Description1 = slider.Description1;
        HVM.Title1 = slider.Title1;
        HVM.sliderImage2Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image2Data);
        HVM.Description2 = slider.Description2;
        HVM.Title2 = slider.Title2;
        HVM.sliderImage3Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image3Data);
        HVM.Description3 = slider.Description3;
        HVM.Title3 = slider.Title3;
        ShopInfo shopInfo = UOW.ShopInfoRepo.GetAll().ToList()[0];
        HVM.ShopPhone = shopInfo.ShopPhone;
        HVM.ShopEmail = shopInfo.ShopEmail;
        HVM.UserId = HttpContext.Session.GetInt32(UserSessionKey);
        HVM.pageTitle = "خانه";
        List<Product> selectedProducts = UOW.ProductRepo.Find(x => x.SelectedForHomePage == true).ToList();
        List<HomePageProducts> homePageSelectedProducts = new List<HomePageProducts>();
        foreach(Product product in selectedProducts)
        {
            string des = "";
            if (product.Description.Length < 60)
            {
                des = product.Description;
            }
            else
            {
                des = product.Description.Substring(0, 60);
            }
            homePageSelectedProducts.Add(new HomePageProducts { title = product.Title, description = des, imageData = product.Image1Data, ProductId = product.Id });

        }
        List<Product> recentProducts = UOW.ProductRepo.GetAll().Reverse().ToList().GetRange(0, 3);
        List<HomePageProducts> homePageRecentProducts = new List<HomePageProducts>();
        foreach(Product product in recentProducts)
        {
            string des = "";
            if(product.Description.Length < 60)
            {
                des = product.Description;
            }
            else
            {
                des = product.Description.Substring(0,60);
            }
            homePageRecentProducts.Add(new HomePageProducts { title = product.Title , description = des , imageData = product.Image1Data,ProductId=product.Id});
        }
        HVM.BigProducts = homePageRecentProducts;
        HVM.Products = homePageSelectedProducts;
        return View(HVM);
    }
    public IActionResult AboutUs()
    {
        AboutUsViewModel AVM = new AboutUsViewModel();
        List<Adds> adds = UOW.AddsRepo.GetAll().ToList();
        Slider slider = UOW.SliderRepo.GetAll().ToList()[0];
        AVM.Adds1Data = ImageAndBytesHandler.ByteArrayToImage(adds[0].ImageData);
        AVM.Adds2Data = ImageAndBytesHandler.ByteArrayToImage(adds[1].ImageData);
        AVM.sliderImage1Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image1Data);
        AVM.Description1 = slider.Description1;
        AVM.Title1 = slider.Title1;
        AVM.sliderImage2Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image2Data);
        AVM.Description2 = slider.Description2;
        AVM.Title2 = slider.Title2;
        AVM.sliderImage3Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image3Data);
        AVM.Description3 = slider.Description3;
        AVM.Title3 = slider.Title3;
        ShopInfo shopInfo = UOW.ShopInfoRepo.GetAll().ToList()[0];
        AVM.ShopPhone = shopInfo.ShopPhone;
        AVM.ShopEmail = shopInfo.ShopEmail;
        AVM.UserId = HttpContext.Session.GetInt32(UserSessionKey);
        AVM.pageTitle = "درباره ما";
        AVM.Description = shopInfo.Description;
        return View(AVM);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
