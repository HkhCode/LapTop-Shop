using System.ComponentModel.DataAnnotations.Schema;
namespace Laptop_shop.Models.Data;

public class Comment
{
    public int Id {get;set;}
    [ForeignKey("user")]
    public int UserId {get;set;}
    public User user {get;set;}
    public string Description {get;set;}
    [ForeignKey("product")]
    public int ProductId {get;set;}
    public Product product {get;set;}
}