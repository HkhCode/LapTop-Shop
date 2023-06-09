using Laptop_shop.Database;
using Laptop_shop.Generic_Repository.interfaces;
namespace Laptop_shop.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;

        }
        public ICardRepo CardRepo
        {
            get;
            private set;
        }
        public ICABRepo CABRepo
        {
            get;
            private set;
        }
        public ICommentRepo CommentRepo
        {
            get;
            private set;
        }
        public IProductRepo ProductRepo
        {
            get;
            private set;
        }
        public IShopInfoRepo ShopInfoRepo
        {
            get;
            private set;
        }
        public ISliderRepo SliderRepo
        {
            get;
            private set;
        }
        public IUserRepo userRepo
        {
            get;
            private set;
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}