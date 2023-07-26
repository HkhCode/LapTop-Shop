using Laptop_shop.ViewModels.PreQuesties;

namespace Laptop_shop.ViewModels.Pages
{
    public class ProductCategoriesViewModel : UserSideLayoutModel
    {
        public string CategoryTitle { get;set; }
        public List<CABPoductViewModel> products { get; set; }
    }
}
