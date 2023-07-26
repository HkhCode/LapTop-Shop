using Laptop_shop.Models.Data;
using Laptop_shop.Generic_Repository.interfaces;
using Laptop_shop.Database;
namespace Laptop_shop.Generic_Repository.Repositories
{
    public class CategoriesRepo : Generic_Repository<Categories> , ICABRepo
    {
        public CategoriesRepo(ApplicationContext context):base(context)
        {

        }
        public List<Categories> GetAllCABs()
        {
            return GetAll().ToList();
        }
        public void DeleteCAB(int id)
        {
            Delete(id);
        }
        public void InsertCAB(Categories cab)
        {
            Insert(cab);
        }
        public List<Categories> GetAllCategories()
        {
            return GetAll().ToList();
        }
    }
}