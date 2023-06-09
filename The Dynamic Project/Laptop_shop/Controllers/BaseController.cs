using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Laptop_shop.Managers;
using Laptop_shop.Models.Data;

namespace Laptop_shop.Controllers;

public class BaseController : Controller
{
    private readonly Generic_Repository<Adds> AddsRepo = new Generic_Repository<Adds>();
    private readonly Generic_Repository<Card> CardRepo = new Generic_Repository<Card>();
    private readonly Generic_Repository<CategoriesAndBrands> CABRepo = new Generic_Repository<CategoriesAndBrands>();
    private readonly Generic_Repository<Comment> CommentRepo = new Generic_Repository<Comment>();
    private readonly Generic_Repository<Product> ProductRepo = new Generic_Repository<Product>();
    private readonly Generic_Repository<ShopInfo> ShopInfoRepo = new Generic_Repository<ShopInfo>();
    private readonly Generic_Repository<Slider> SliderRepo = new Generic_Repository<Slider>();
    private readonly Generic_Repository<User> UserRepo = new Generic_Repository<User>();
}