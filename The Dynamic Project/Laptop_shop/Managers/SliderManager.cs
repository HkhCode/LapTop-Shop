using Laptop_shop.Generic_Repository;
using Laptop_shop.Models.Data;

namespace Laptop_shop.Managers
{
    public class SliderManager
    {
        private readonly Generic_Repository<Slider> SliderRepo = new Generic_Repository<Slider>();
        public List<Slider> GetSliderData()
        {
            return SliderRepo.GetAll().ToList();
        }
        public void DeleteSliderData(int id)
        {
            SliderRepo.Delete(id);
        }
        public void AddSliderData(Slider slider)
        {
            SliderRepo.Insert(slider);
        }
    }
}
