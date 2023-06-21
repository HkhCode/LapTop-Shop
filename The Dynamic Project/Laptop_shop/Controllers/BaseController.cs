using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Laptop_shop.Models;
using Laptop_shop.Unit_Of_Work;
using Laptop_shop.Generic_Repository.Repositories;
using Laptop_shop.Database;

namespace Laptop_shop.Controllers;

public class BaseController : Controller
{
    protected readonly UnitOfWork UOW = new UnitOfWork(new ApplicationContext());
}