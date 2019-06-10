using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAppApi.Repository
{
    /// <summary>
    /// Interface de exemplo de implementação de generic repository pattern
    /// Repository Pattern separa logica de acesso a dados e mapeia as entidades normalmente utilizado para criação de CRUD.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
