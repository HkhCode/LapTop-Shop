using Laptop_shop.Models.Data;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

namespace Laptop_shop.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("Shop")
        {
        }
        public DbSet<Adds> Adds { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShopInfo> ShopInfos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}