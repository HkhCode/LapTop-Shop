using System.ComponentModel.DataAnnotations.Schema;
namespace Laptop_shop.Models.Data;

public class Card
{
    public int Id {get;set;}
    [ForeignKey("user")]
    public int UserId {get;set;}
    public User user {get;set;}
    public virtual ICollection<Product> Products {get;set;}
}