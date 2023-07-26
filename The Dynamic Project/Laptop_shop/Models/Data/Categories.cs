namespace Laptop_shop.Models.Data;

public class Categories
{
    public int Id {get;set;}
    public string Title {get;set;}
    public virtual ICollection<Product> Products {get;set;}
}