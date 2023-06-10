using Laptop_shop.Models.Data;
using Laptop_shop.Generic_Repository.interfaces;
using Laptop_shop.Database;
using Laptop_shop.Models.Data;
namespace Laptop_shop.Generic_Repository.Repositories
{
    public class ShopInfoRepo : Generic_Repository<ShopInfo>, IShopInfoRepo
    {
        public ShopInfoRepo(ApplicationContext context) : base(context)
        {

        }
        public void UpdateShopInfo(ShopInfo shopInfo)
        {
            Update(shopInfo);
        }
        public void AddShopInfo(ShopInfo shopInfo)
        {
            Insert(shopInfo);
        }
    }
}