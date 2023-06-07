using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Laptop_shop.Models;
using Laptop_shop.Managers;

namespace Laptop_shop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProductManager _productManager = new ProductManager();
    private readonly UserManager _userManager = new UserManager();
    private readonly AddsManager _addsManager = new AddsManager();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
