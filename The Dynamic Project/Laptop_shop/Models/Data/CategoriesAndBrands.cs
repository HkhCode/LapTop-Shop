namespace Laptop_shop.Models.Data;

public class CategoriesAndBrands
{
    public int Id {get;set;}
    public string Title {get;set;}
    public int BrandOrCategory {get;set;}
    public virtual ICollection<Product> Products {get;set;}
}