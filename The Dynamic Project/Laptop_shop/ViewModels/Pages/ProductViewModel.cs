using Laptop_shop.Models.Data;
using Laptop_shop.Models.Enums;
using Laptop_shop.ViewModels.PreQuesties;

namespace Laptop_shop.ViewModels.Pages
{
    public class ProductViewModel : UserSideLayoutModel
    {
        public int Id { get; set; }
        public string Image1Data { get; set; }
        public string Image2Data { get; set; }
        public string Image3Data { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CPUModel { get; set; }
        public string GPUModel { get; set; }
        public string HardDrive { get; set; }
        public Ram RamType { get; set; }
        public int RamAmount { get; set; }
        public string Battery { get; set; }
        public int Weight { get; set; }
        public virtual ICollection<Categories> Categories { get; set; }
        public virtual List<CommentsViewModel> Comments { get; set; }
    }
}
