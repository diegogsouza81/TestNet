using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using webAppApi.ADO;

namespace webAppApi.Repository
{

    /// <summary>
    /// Implementação de classe pattern repositorio generico
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DatabaseContext _context = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this._context = new DatabaseContext();
            table = _context.Set<T>();
        }

        public GenericRepository(DatabaseContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return table;
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}