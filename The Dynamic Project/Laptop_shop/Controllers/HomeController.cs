using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Laptop_shop.Models;
using Laptop_shop.Models.Data;

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
        List<Adds> adds = UOW.AddsRepo.GetAll().ToList();
        return View(adds);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
