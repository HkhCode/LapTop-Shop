using Laptop_shop.Generic_Repository;
using Laptop_shop.Models.Data;

namespace Laptop_shop.Managers
{
    public class ShopInfoManager
    {
        private readonly Generic_Repository<ShopInfo> ShopInfoRepo = new Generic_Repository<ShopInfo>();
        public List<ShopInfo> GetShopInfo()
        {
            return ShopInfoRepo.GetAll().ToList();
        }
        public void DeleteShopInfo(int id)
        {
            ShopInfoRepo.Delete(id);
        }
        public void AddShopInfo(ShopInfo shopInfo)
        {
            ShopInfoRepo.Insert(shopInfo);
        }
    }
}
