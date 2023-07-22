using Laptop_shop.Utilities;
using Laptop_shop.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Laptop_shop.Controllers
{
    public class ForgetPasswordController : BaseController
    {
        public IActionResult Index()
        {
            ForgetPasswordViewModel FPVM = new ForgetPasswordViewModel();
            return View(FPVM);
        }
        [HttpPost]
        public IActionResult Index(ForgetPasswordViewModel FPVM)
        {
            try
            {
                string email = UOW.UserRepo.Find(x => x.Email == FPVM.UserEmail).First().Email;
                MailMessage mail = new MailMessage();
                string NewPassword = PasswordGenerator.Generate(8);
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(ShopEmail);
                mail.To.Add(email);
                mail.Subject = "بازیابی کلمه عبور";
                mail.Body = $"کلمه عبور جدید : {NewPassword} \n از این کلمه عبور برای ورود استفاده کنید \n رمز شما از پنل کاربری تان قابل تغییر می باشد";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(ShopEmail, ShopEmailPassword);
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Send(mail);
                return Redirect("/Login/Index");
            }
            catch
            {
                ForgetPasswordViewModel fpvm = new ForgetPasswordViewModel();
                fpvm.Message = "ایمیل وارد شده در سایت یافت نشد !";
                return View(fpvm);
            }
        }
    }
}
