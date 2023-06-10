using Laptop_shop.Models.Data;
using Laptop_shop.Generic_Repository.interfaces;
using Laptop_shop.Database;
using Laptop_shop.Models.Data;
namespace Laptop_shop.Generic_Repository.Repositories
{
    public class UserRepo : Generic_Repository<User> , IUserRepo
    {
        public UserRepo(ApplicationContext context) : base(context)
        {
            
        }
        public void AddUser(User user)
        {
            Insert(user);
        }
        public void UpdateUser(User user)
        {
            Update(user);
        }
        public User GetUser(int id)
        {
            return GetById(id);
        }
    }
}