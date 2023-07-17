using Laptop_shop.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laptop_shop.Models.Data;

public class User
{
    public int Id {get; set;}
    public string Name {get;set;}
    public string Family { get; set; }
    public string Password {get;set;}
    public string Email {get;set;}
    public string PhoneNumber {get;set;}
    public Role Role { get;set;}
}