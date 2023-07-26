using Laptop_shop.Models.Data;

namespace Laptop_shop.ViewModels.Pages
{
    public class CategoriesAndBrandsViewModel : UserSideLayoutModel
    {
        public List<Categories> Categories { get; set; }
        public List<Brand> Brands { get; set; }
    }
}