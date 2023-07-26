using Laptop_shop.Models.Data;
using Laptop_shop.Utilities;
using Laptop_shop.ViewModels.Pages;
using Laptop_shop.ViewModels.PreQuesties;
using Microsoft.AspNetCore.Mvc;

namespace Laptop_shop.Controllers
{
    public class CategoriesAndBrandsController : BaseController
    {
        public IActionResult Index()
        {
            CategoriesAndBrandsViewModel CABVM = new CategoriesAndBrandsViewModel();
            List<Adds> adds = UOW.AddsRepo.GetAll().ToList();
            Slider slider = UOW.SliderRepo.GetAll().ToList()[0];
            CABVM.Adds1Data = ImageAndBytesHandler.ByteArrayToImage(adds[0].ImageData);
            CABVM.Adds2Data = ImageAndBytesHandler.ByteArrayToImage(adds[1].ImageData);
            CABVM.sliderImage1Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image1Data);
            CABVM.Description1 = slider.Description1;
            CABVM.Title1 = slider.Title1;
            CABVM.sliderImage2Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image2Data);
            CABVM.Description2 = slider.Description2;
            CABVM.Title2 = slider.Title2;
            CABVM.sliderImage3Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image3Data);
            CABVM.Description3 = slider.Description3;
            CABVM.Title3 = slider.Title3;
            ShopInfo shopInfo = UOW.ShopInfoRepo.GetAll().ToList()[0];
            CABVM.ShopPhone = shopInfo.ShopPhone;
            CABVM.ShopEmail = shopInfo.ShopEmail;
            CABVM.UserId = HttpContext.Session.GetInt32(UserSessionKey);
            CABVM.pageTitle = "دسته بندی ها";
            CABVM.Categories = UOW.CABRepo.GetAll().ToList();
            CABVM.Brands = UOW.BrandRepo.GetAll().ToList();
            return View(CABVM);
        }
        public IActionResult FindByCategory(int id)
        {
            ProductCategoriesViewModel PCVM = new ProductCategoriesViewModel();
            Categories Category = UOW.CABRepo.Find(x => x.Id == id).FirstOrDefault();
            List<Adds> adds = UOW.AddsRepo.GetAll().ToList();
            Slider slider = UOW.SliderRepo.GetAll().ToList()[0];
            PCVM.Adds1Data = ImageAndBytesHandler.ByteArrayToImage(adds[0].ImageData);
            PCVM.Adds2Data = ImageAndBytesHandler.ByteArrayToImage(adds[1].ImageData);
            PCVM.sliderImage1Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image1Data);
            PCVM.Description1 = slider.Description1;
            PCVM.Title1 = slider.Title1;
            PCVM.sliderImage2Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image2Data);
            PCVM.Description2 = slider.Description2;
            PCVM.Title2 = slider.Title2;
            PCVM.sliderImage3Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image3Data);
            PCVM.Description3 = slider.Description3;
            PCVM.Title3 = slider.Title3;
            ShopInfo shopInfo = UOW.ShopInfoRepo.GetAll().ToList()[0];
            PCVM.ShopPhone = shopInfo.ShopPhone;
            PCVM.ShopEmail = shopInfo.ShopEmail;
            PCVM.UserId = HttpContext.Session.GetInt32(UserSessionKey);
            PCVM.pageTitle = Category.Title;
            PCVM.products = new List<CABPoductViewModel>();
            foreach(Product p in Category.Products)
            {
                PCVM.products.Append(new CABPoductViewModel
                {
                    Title = p.Title,
                    Description = p.Description,
                    Image = ImageAndBytesHandler.ByteArrayToImage(p.Image1Data),
                    Id = p.Id
                });
            }
            return View(PCVM);
        }
        public IActionResult FindByBrand(int id)
        {
            BrandProductsViewModel BPVM = new BrandProductsViewModel();
            Brand brand = UOW.BrandRepo.GetById(id);
            List<Adds> adds = UOW.AddsRepo.GetAll().ToList();
            Slider slider = UOW.SliderRepo.GetAll().ToList()[0];
            BPVM.Adds1Data = ImageAndBytesHandler.ByteArrayToImage(adds[0].ImageData);
            BPVM.Adds2Data = ImageAndBytesHandler.ByteArrayToImage(adds[1].ImageData);
            BPVM.sliderImage1Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image1Data);
            BPVM.Description1 = slider.Description1;
            BPVM.Title1 = slider.Title1;
            BPVM.sliderImage2Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image2Data);
            BPVM.Description2 = slider.Description2;
            BPVM.Title2 = slider.Title2;
            BPVM.sliderImage3Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image3Data);
            BPVM.Description3 = slider.Description3;
            BPVM.Title3 = slider.Title3;
            ShopInfo shopInfo = UOW.ShopInfoRepo.GetAll().ToList()[0];
            BPVM.ShopPhone = shopInfo.ShopPhone;
            BPVM.ShopEmail = shopInfo.ShopEmail;
            BPVM.UserId = HttpContext.Session.GetInt32(UserSessionKey);
            BPVM.pageTitle = brand.Title;
            BPVM.products = new List<CABPoductViewModel>();
            foreach(Product p in brand.Products)
            {
                BPVM.products.Append(new CABPoductViewModel()
                {
                    Id = p.Id,
                    Description = p.Description,
                    Title = p.Title,
                    Image = ImageAndBytesHandler.ByteArrayToImage(p.Image1Data)
                });
            }
            return View(BPVM);
        }
    }
}
