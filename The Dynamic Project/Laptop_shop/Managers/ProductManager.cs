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
        public List<Product> GetLast6Products()
        {
            List<Product> result = new List<Product>();
            List<Product> products = ProductRepo.GetAll().Reverse().ToList();
            for(int i = 0; i <= 5; i++)
            {
                result.Append(products[i]);
            }
            return result;
        }
        public List<Product> GetSelectedProducts()
        {
            List<Product> result = new List<Product>();
            foreach (Product p in ProductRepo.GetAll().Where(x => x.SelectedForHomePage == true))
            {
                result.Append(p);
            }
            return result;
        }
    }
}
