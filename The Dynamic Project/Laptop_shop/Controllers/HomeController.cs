using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Laptop_shop.Models;
using Laptop_shop.Managers;
using Laptop_shop.ViewModels.Pages;
using Laptop_shop.Models.Data;

namespace Laptop_shop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProductManager _productManager = new ProductManager();
    private readonly UserManager _userManager = new UserManager();
    private readonly AddsManager _addsManager = new AddsManager();
    private readonly ShopInfoManager shopInfoManager = new ShopInfoManager();
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        HomeViewModel HVM = new HomeViewModel();
        List<HomePageProducts> hppNormal = new List<HomePageProducts>();
        List<HomePageProducts> hppBig = new List<HomePageProducts>();
        List<Product> Last6Products = _productManager.GetLast6Products();
        foreach(Product p in Last6Products)
        {
            hppNormal.Append(new HomePageProducts() { title =  p.Title, description = p.Description,imageData = p.Image1Date , ProductId = p.Id})
        }
        foreach(Product p in _productManager.GetSelectedProducts())
        {
            hppBig.Append(new HomePageProducts() { title = p.Title, description = p.Description, imageData = p.Image1Date, ProductId = p.Id });
        }
        HVM.Products = hppNormal;
        HVM.BigProducts = hppBig;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
