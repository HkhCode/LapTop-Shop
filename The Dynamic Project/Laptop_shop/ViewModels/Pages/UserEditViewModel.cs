using System.ComponentModel.DataAnnotations;

namespace Laptop_shop.ViewModels.Pages
{
    public class UserEditViewModel : UserSideLayoutModel
    {
        [Required , Display(Name = "نام")]
        public string Name { get; set; }
        [Required, Display(Name = "نام خانوادگی")]
        public string Family { get; set; }
        [Required, Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Required, Display(Name = "شماره تماس")]
        public string Phone { get; set; }
        [Required, Display(Name = "کلمه عبور")]
        public string Password { get; set; }
        [Required, Display(Name = "تکرار کلمه عبور")]
        public string RepeatPassword { get; set; }
        public string Message { get; set; }
    }
}
