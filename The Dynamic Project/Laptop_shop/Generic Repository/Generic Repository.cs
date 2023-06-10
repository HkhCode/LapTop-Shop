using Laptop_shop.Database;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq.Expressions;

namespace Laptop_shop.Generic_Repository
{
    public class Generic_Repository<T> : IGeneric_Repository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        protected DbSet<T> table;
        public Generic_Repository(ApplicationContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return table.Where(expression);
        }
        public void Insert(T obj)
        {
            //It will mark the Entity state as Added State
            table.Add(obj);
            Save();
        }
        public void Delete(object id)
        {
            //First, fetch the record from the table
            T existing = table.Find(id);
            //This will mark the Entity State as Deleted
            table.Remove(existing);
            Save();
        }
        public void Update(T obj)
        {
            table.AddOrUpdate(obj);
        }

    }
}
