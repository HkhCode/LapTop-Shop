using Laptop_shop.Generic_Repository;
using Laptop_shop.Models.Data;

namespace Laptop_shop.Managers
{
    public class UserManager
    {
        private readonly Generic_Repository<User> UserRepo = new Generic_Repository<User>();
        public User GetUser(int id)
        {
            return UserRepo.GetById(id);
        }
        public void AddUser(User user)
        {
            UserRepo.Insert(user);
        }
        public void UpdateUser(User user)
        {
            UserRepo.Delete(user.Id);
            UserRepo.Insert(user);
        }
    }
}
