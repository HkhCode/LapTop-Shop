using Laptop_shop.Database;
using Laptop_shop.Generic_Repository.interfaces;
using Laptop_shop.Models.Data;

namespace Laptop_shop.Generic_Repository.Repositories
{
    public class BrandRepo : Generic_Repository<Brand> , IBrandRepo
    {
        public BrandRepo(ApplicationContext context) : base(context) { }
        public List<Brand> GetAllBrands()
        {
            return GetAll().ToList();
        }
        public Brand Get(int id)
        {
            return Find(x=> x.Id == id).FirstOrDefault();
        }
        public void InsertBrand(Brand brand)
        {
            Insert(brand);
        }
        public void DeleteBrand(int id)
        {
            Delete(id);
        }
    }
}
