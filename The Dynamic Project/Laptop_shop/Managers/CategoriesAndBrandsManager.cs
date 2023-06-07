using Laptop_shop.Generic_Repository;
using Laptop_shop.Models.Data;

namespace Laptop_shop.Managers
{
    public class CategoriesAndBrandsManager
    {
        private readonly Generic_Repository<CategoriesAndBrands> CategoriesAndBrandsRepo = new Generic_Repository<CategoriesAndBrands>();

        public List<CategoriesAndBrands> GetAllCategories()
        {
            return CategoriesAndBrandsRepo.GetAll().ToList();
        }
        public void AddCategoryOrBrand(CategoriesAndBrands CAB)
        {
            CategoriesAndBrandsRepo.Insert(CAB);
        }
        public void Delete(int id) 
        {
            CategoriesAndBrandsRepo.Delete(id);
        }
    }
}
