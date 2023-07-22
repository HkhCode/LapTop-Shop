using Laptop_shop.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace Laptop_shop.ViewModels.Pages
{
    public class SignupViewModel
    {
        [Required , Display(Name = "نام")]
        public string Name { get; set; }
        [Required, Display(Name = "نام خانوادگی")]
        public string Family { get; set; }
        [Required, Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Required, Display(Name = "موبایل")]
        public string Phone { get; set; }
        [Required, Display(Name = "کلمه عبور")]
        public string Password { get; set; }
        [Required, Display(Name = "تکرار کلمه عبور")]
        public string PasswordRepeat { get; set; }
        [Required, Display(Name = "قوانین و مقررات را می پذیرم")]
        public bool AcceptRules { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
