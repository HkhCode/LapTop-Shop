using Laptop_shop.Generic_Repository.interfaces;
using Laptop_shop.Generic_Repository.Repositories;

namespace Laptop_shop.Unit_Of_Work
{
    public interface IUnitOfWork : IDisposable
    {
        IAddsRepo AddsRepo {get;}
        ICardRepo CardRepo {get;}
        ICABRepo CABRepo {get;}
        ICommentRepo CommentRepo {get;}
        IProductRepo ProductRepo {get;}
        IShopInfoRepo ShopInfoRepo {get;}
        ISliderRepo SliderRepo {get;}
        IUserRepo UserRepo {get;}
        IBrandRepo BrandRepo { get;}
        int Save();
    }
}

