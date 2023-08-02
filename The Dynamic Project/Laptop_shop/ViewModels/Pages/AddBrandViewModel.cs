using System.ComponentModel.DataAnnotations;

namespace Laptop_shop.ViewModels.Pages
{
    public class AddBrandViewModel: AdminSideLayoutModel
    {
        [Display(Name = "نام برند")]
        public string BrandTitle { get; set; }
    }
}
