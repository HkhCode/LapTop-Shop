using Laptop_shop.Models.Data;
using Laptop_shop.Generic_Repository.interfaces;
using Laptop_shop.Database;
using Laptop_shop.Models.Data;
namespace Laptop_shop.Generic_Repository.Repositories
{
    public class ProductRepo : Generic_Repository<Product> , IProductRepo
    {
        public ProductRepo(ApplicationContext context) : base(context)
        {
            
        }
    }
}