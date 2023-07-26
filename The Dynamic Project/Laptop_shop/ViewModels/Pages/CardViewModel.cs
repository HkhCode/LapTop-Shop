using Laptop_shop.ViewModels.PreQuesties;

namespace Laptop_shop.ViewModels.Pages
{
    public class CardViewModel : UserSideLayoutModel
    {
        public List<UserSideProduct> Products { get; set; }
        public int FullPrice { get; set; }
    }
}
