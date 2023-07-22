using System.ComponentModel.DataAnnotations;

namespace Laptop_shop.ViewModels.Pages
{
    public class ForgetPasswordViewModel
    {
        [Required , Display(Name = "ایمیل")]
        public string UserEmail { get; set; }
        public string Message { get; set; }
    }
}
