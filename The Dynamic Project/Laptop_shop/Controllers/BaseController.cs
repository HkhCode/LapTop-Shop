using Microsoft.AspNetCore.Mvc;
using Laptop_shop.Unit_Of_Work;
using Laptop_shop.Database;
using Laptop_shop.Models.Enums;
using Laptop_shop.Models.Data;

namespace Laptop_shop.Controllers;

public class BaseController : Controller
{
    protected readonly UnitOfWork UOW = new UnitOfWork(new ApplicationContext());
    protected readonly string UserSessionKey = "UserId";
    protected readonly string ShopEmail = "shopir212112@gmail.com";
    protected readonly string ShopEmailPassword = "testShop22";
    public bool AdminAuthnticate(string Email , string Password , string RepeatPassword)
    {
        try
        {
            User Admin = UOW.UserRepo.Find(x => x.Email == Email).First();
            if(Password == RepeatPassword)
            {
                return true;
            }
            else { return false; }
        }
        catch
        {
            return false;
        }
    }
    public bool AdminAuthorize(int id)
    {
        try
        {
            User Admin = UOW.UserRepo.GetById(id);
            if (Admin.Role == Role.Admin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }
}