﻿using Laptop_shop.Database;
using System.Data.Entity;

namespace Laptop_shop.Generic_Repository
{
    public class Generic_Repository<T> where T : class
    {
        private readonly ApplicationContext _context;
        private DbSet<T> table;
        public Generic_Repository()
        {
            this._context = new ApplicationContext();
            table = _context.Set<T>();
        }

        public Generic_Repository(ApplicationContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            //It will mark the Entity state as Added State
            table.Add(obj);
        }
        public void Delete(object id)
        {
            //First, fetch the record from the table
            T existing = table.Find(id);
            //This will mark the Entity State as Deleted
            table.Remove(existing);
        }
        public void Update(T obj)
        {
            table.Remove(obj);
            table.Add(obj);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}