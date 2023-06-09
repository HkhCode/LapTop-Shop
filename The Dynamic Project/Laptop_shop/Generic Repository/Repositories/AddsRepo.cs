using Laptop_shop.Models.Data;
using Laptop_shop.Generic_Repository.interfaces;
using Laptop_shop.Database;
using Laptop_shop.Models.Data;
namespace Laptop_shop.Generic_Repository.Repositories
{
    public class AddsRepo : Generic_Repository<Adds> , IAddsRepo
    {
        public AddsRepo(ApplicationContext context):base(context)
        {

        }
        public List<Adds> GetAdds()
        {
            return GetAll().ToList();
        }
        public void DeleteAdd(int id)
        {
            Delete(id);
        }
        public void InsertAdd(Adds add)
        {
            Insert(add);
        }
    }
}