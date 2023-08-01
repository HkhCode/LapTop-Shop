using Laptop_shop.Models.Data;
using Laptop_shop.Generic_Repository.interfaces;
using Laptop_shop.Database;
using Laptop_shop.Models.Data;
namespace Laptop_shop.Generic_Repository.Repositories
{
    public class ProductRepo : Generic_Repository<Product> , IProductRepo
    {
        public ProductRepo(ApplicationContext context) : base(context)
        {
            
        }
        public Product GetProduct(int id)
        {
            return GetById(id);
        }
        public List<Product> GetSearchedProducts(string name)
        {
            return Find(x=> x.Title == name).ToList();
        }
        public List<Product> GetLast6Products()
        {
            List<Product> products = new List<Product>();
            List<Product> GottenProdcucts = GetAll().Reverse().ToList();
            products.Append(GottenProdcucts[0]);
            products.Append(GottenProdcucts[1]);
            products.Append(GottenProdcucts[2]);
            products.Append(GottenProdcucts[3]);
            products.Append(GottenProdcucts[4]);
            products.Append(GottenProdcucts[5]);
            return products;
        }
        public List<Product> GetSelectedProducts()
        {
            return Find(x => x.SelectedForHomePage == true).ToList();
        }
        public void AddProduct(Product product)
        {
            Insert(product);
        }
        public void DeleteProduct(int id)
        {
            Delete(id);
        }
        public void UpdateProdcut(Product product)
        {
            Update(product);
        }
    }
}