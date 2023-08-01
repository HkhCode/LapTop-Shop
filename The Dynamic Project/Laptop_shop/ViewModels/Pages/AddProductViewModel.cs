using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Laptop_shop.ViewModels.Pages
{
    public class AddProductViewModel : AdminSideLayoutModel
    {
        [Display(Name = "نام کالا")]
        public string ProductTitle { get; set; }
        [Display(Name = "تصویر اول")]
        public IFormFile Image1Data { get; set; }
        [Display(Name = "تصویر دوم")]
        public IFormFile Image2Data { get; set; }
        [Display(Name = "تصویر سوم")]
        public IFormFile Image3Data { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "پردازنده")]
        public string CPU { get; set; }
        [Display(Name = "کارت گرافیک")]
        public string GPU { get; set; }
        [Display(Name = "مقدار رم")]
        public int RamAmount { get; set; }
        [Display(Name = "نوع رم")]
        public string RamType { get; set; }
        [Display(Name = "هارد")]
        public string Hard { get; set; }
        [Display(Name = "باطری")]
        public string Battery { get; set; }
        [Display(Name = "وزن")]
        public string Weight { get; set; }
        [Display(Name = "قیمت")]
        public int Price { get; set; }
        [Display(Name = "برند")]
        public string Brand { get; set; }
        [Display(Name = "کاربردها")]
        public string Usages { get; set; }
    }
}
