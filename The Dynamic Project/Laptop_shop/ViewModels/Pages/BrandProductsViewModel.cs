using Laptop_shop.ViewModels.PreQuesties;

namespace Laptop_shop.ViewModels.Pages
{
    public class BrandProductsViewModel : UserSideLayoutModel
    {
        public string BrandTitle { get; set; }
        public List<CABPoductViewModel> products { get; set; }
    }
}
