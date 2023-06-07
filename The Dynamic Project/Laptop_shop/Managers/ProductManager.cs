using Laptop_shop.Generic_Repository;
using Laptop_shop.Models.Data;

namespace Laptop_shop.Managers
{
    public class ProductManager
    {
        private readonly Generic_Repository<Product> ProductRepo = new Generic_Repository<Product>();

        public void AddProduct(Product product)
        {
            ProductRepo.Insert(product);
        }
        public List<Product> GetAllProducts() 
        {
            return ProductRepo.GetAll().ToList();
        }
        public void DeleteProduct(int id)
        {
            ProductRepo.Delete(id);
        }
        public void UpdateProduct(Product product) 
        {
            DeleteProduct(product.Id);
            AddProduct(product);
        }
    }
}
