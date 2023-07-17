using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace Laptop_shop.ViewModels.Pages
{
    public class LoginViewModel
    {
        [Required , Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Required, Display(Name = "کلمه عبور")]
        public string Password { get; set; }
        public string Message { get; set; }
    }
}
