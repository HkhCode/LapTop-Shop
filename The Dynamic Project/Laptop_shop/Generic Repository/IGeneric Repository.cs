using System.Linq.Expressions;

namespace Laptop_shop.Generic_Repository
{
    public interface IGeneric_Repository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Insert(T Entity);
        void Delete(object id);
        void Update(T obj);
        void Save();
    }
}

