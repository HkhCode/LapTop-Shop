using Laptop_shop.Models.Data;
using Laptop_shop.Utilities;
using Laptop_shop.ViewModels.Pages;
using Laptop_shop.ViewModels.PreQuesties;
using Microsoft.AspNetCore.Mvc;

namespace Laptop_shop.Controllers
{
    public class ProductController : BaseController
    {
        public IActionResult Index(int id)
        {
            Product product = UOW.ProductRepo.Find(x=>x.Id == id).FirstOrDefault();
            ProductViewModel PVM = new ProductViewModel();
            List<Adds> adds = UOW.AddsRepo.GetAll().ToList();
            Slider slider = UOW.SliderRepo.GetAll().ToList()[0];
            PVM.Adds1Data = ImageAndBytesHandler.ByteArrayToImage(adds[0].ImageData);
            PVM.Adds2Data = ImageAndBytesHandler.ByteArrayToImage(adds[1].ImageData);
            PVM.sliderImage1Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image1Data);
            PVM.Description1 = slider.Description1;
            PVM.Title1 = slider.Title1;
            PVM.sliderImage2Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image2Data);
            PVM.Description2 = slider.Description2;
            PVM.Title2 = slider.Title2;
            PVM.sliderImage3Data = ImageAndBytesHandler.ByteArrayToImage(slider.Image3Data);
            PVM.Description3 = slider.Description3;
            PVM.Title3 = slider.Title3;
            ShopInfo shopInfo = UOW.ShopInfoRepo.GetAll().ToList()[0];
            PVM.ShopPhone = shopInfo.ShopPhone;
            PVM.ShopEmail = shopInfo.ShopEmail;
            PVM.UserId = HttpContext.Session.GetInt32(UserSessionKey);
            PVM.pageTitle = product.Title;
            PVM.Title = product.Title;
            PVM.Id = product.Id;
            PVM.Image1Data = ImageAndBytesHandler.ByteArrayToImage(product.Image1Data);
            PVM.Image3Data = ImageAndBytesHandler.ByteArrayToImage(product.Image2Data);
            PVM.Image2Data = ImageAndBytesHandler.ByteArrayToImage(product.Image3Data);
            PVM.Description = product.Description;
            PVM.CPUModel = product.CPUModel;
            PVM.GPUModel = product.GPUModel;
            PVM.HardDrive = product.HardDrive;
            PVM.RamType = product.RamType;
            PVM.RamAmount = product.RamAmount;
            PVM.Battery = product.Battery;
            PVM.Weight = product.Weight;
            PVM.Usage = product.Usages;
            PVM.Comments = new List<CommentsViewModel>();
            foreach(Comment comment in product.Comments)
            {
                CommentsViewModel CVM = new CommentsViewModel();
                User user = UOW.UserRepo.Find(x => x.Id == comment.UserId).FirstOrDefault();
                CVM.Writter_Username = user.Name + " " + user.Family;
                CVM.Text = comment.Description;
                PVM.Comments.Append(CVM);
            }
            return View(PVM);
        }
        public IActionResult AddProduct()
        {
            try
            {
                int id = (int)HttpContext.Session.GetInt32(UserSessionKey);
                if (AdminAuthorize(id))
                {
                    AddProductViewModel APVM = new AddProductViewModel();
                    APVM.Title= "افزودن کالا";
                    return View(APVM);
                }
                else
                {
                    return Redirect("/Login/Index");
                }
            }
            catch
            {
                return Redirect("/Login/Index");
            }
        }
        [HttpPost]
        //AddProductViewModel APVM , IFormFile file1, IFormFile file2, 
        public IActionResult AddProduct([FromForm]AddProductViewModel APVM)
        {
            Product product = new Product();
            product.Title = APVM.ProductTitle;
            product.CPUModel = APVM.CPU;
            product.GPUModel = APVM.GPU;
            product.RamAmount = APVM.RamAmount;
            switch(APVM.RamType.ToLower())
            {
                case "ddr1":
                    product.RamType = Models.Enums.Ram.ddr1;
                    break;
                case "ddr2":
                    product.RamType = Models.Enums.Ram.ddr2;
                    break;
                case "ddr3":
                    product.RamType = Models.Enums.Ram.ddr3;
                    break;
                case "ddr4":
                    product.RamType = Models.Enums.Ram.ddr4;
                    break;
                case "ddr5":
                    product.RamType = Models.Enums.Ram.ddr5;
                    break;
                case "ddr6":
                    product.RamType = Models.Enums.Ram.ddr6;
                    break;
                default:
                    throw new Exception("Wrong Ram Type !");
            }
            product.Battery = APVM.Battery;
            product.Weight = int.Parse(APVM.Weight);
            using(MemoryStream ms = new MemoryStream())
            {
                APVM.Image1Data.CopyTo(ms);
                product.Image1Data = ms.ToArray();
            }
            using (MemoryStream ms = new MemoryStream())
            {
                APVM.Image2Data.CopyTo(ms);
                product.Image2Data = ms.ToArray();
            }
            using (MemoryStream ms = new MemoryStream())
            {
                APVM.Image3Data.CopyTo(ms);
                product.Image3Data = ms.ToArray();
            }
            product.Usages = APVM.Usages;
            product.Description = APVM.Description;
            try
            {
                Brand brand = UOW.BrandRepo.Find(x => x.Title == APVM.Brand).First();
                product.Brand = brand;
            }
            catch
            {
                return Redirect("/product/AddProduct");
            }
            UOW.ProductRepo.Insert(product);
            return Redirect("/Admin/Index");
            
        }
        public IActionResult EditProduct(int id)
        {
            return View();
        }
        public IActionResult DeleteProduct(int id)
        {
            return View();
        }
    }
}
