using Laptop_shop.Models.Data;
using Laptop_shop.ViewModels.Pages;
using Laptop_shop.ViewModels.PreQuesties;
using Microsoft.AspNetCore.Mvc;

namespace Laptop_shop.Controllers
{
    public class ProductSettingsController : BaseController
    {
        public IActionResult Index()
        {
            ProductSettingsViewModel PSVM = new ProductSettingsViewModel();
            PSVM.products = new List<UserSideProduct>();
            List<Product> Gotten_Date = UOW.ProductRepo.GetAll().ToList();
            foreach(Product p in Gotten_Date)
            {
                PSVM.products.Append(new UserSideProduct() {Title = p.Title , Id = p.Id , Price = p.Price });
            }
            return View(PSVM);
        }
    }
}
