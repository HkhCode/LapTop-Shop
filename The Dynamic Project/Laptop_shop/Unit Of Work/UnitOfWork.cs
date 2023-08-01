using Laptop_shop.Database;
using Laptop_shop.Generic_Repository.interfaces;
using Laptop_shop.Generic_Repository.Repositories;

namespace Laptop_shop.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            AddsRepo = new AddsRepo(_context);
            CardRepo = new CardRepo(_context);
            CommentRepo = new CommentRepo(_context);
            ProductRepo = new ProductRepo(_context);
            ShopInfoRepo = new ShopInfoRepo(_context);
            SliderRepo = new SliderRepo(_context);
            UserRepo = new UserRepo(_context);
            BrandRepo = new BrandRepo(_context);
        }
        public IAddsRepo AddsRepo
        {
            get;
            private set;
        }
        public IBrandRepo BrandRepo
        {
            get;
            private set;
        }
        public ICardRepo CardRepo
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
        public IUserRepo UserRepo
        {
            get;
            private set;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}