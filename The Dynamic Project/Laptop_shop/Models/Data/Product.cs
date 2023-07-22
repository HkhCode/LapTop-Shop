using Laptop_shop.Models.Enums;
namespace Laptop_shop.Models.Data;

public class Product
{
    public int Id { get; set; }
    public byte[] Image1Data { get; set; }
    public byte[] Image2Data { get; set; }
    public byte[] Image3Data { get; set; }
    public string Title {get;set;}
    public string Description {get;set;}
    public int Count {get;set;}
    public string CPUModel {get;set;}
    public string GPUModel {get;set;}
    public string HardDrive {get;set;}
    public Ram RamType {get;set;}
    public int RamAmount {get;set;}
    public string Battery {get;set;}
    public int Weight {get;set;}
    public bool SelectedForHomePage { get;set;}
    public virtual ICollection<CategoriesAndBrands> Categories {get;set;}
    public virtual ICollection<Comment> Comments {get;set;}
    public virtual ICollection<Card> Cards { get; set; }
}