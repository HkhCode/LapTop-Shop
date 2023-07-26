namespace Laptop_shop.Models.Data
{
    public class Brand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
