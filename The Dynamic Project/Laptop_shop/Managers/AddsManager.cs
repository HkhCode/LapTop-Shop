using Laptop_shop.Generic_Repository;
using Laptop_shop.Models.Data;

namespace Laptop_shop.Managers
{
    public class AddsManager
    {
        private readonly Generic_Repository<Adds> AddRepo = new Generic_Repository<Adds>();
        public List<Adds> GetAdds()
        {
            return AddRepo.GetAll().ToList();
        }
        public void DeleteAdd(Adds add)
        {
            AddRepo.Delete(add.Id);
        }
        public void AddAdds(Adds add)
        {
            AddRepo.Insert(add);
        }
    }
}
