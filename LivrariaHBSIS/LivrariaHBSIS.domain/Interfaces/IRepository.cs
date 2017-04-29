using System.Collections.Generic;

namespace LivrariaHBSIS.domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Save(T obj);
        void Update(T obj);
        void Delete(T obj);
        T GetById(long id);
        IEnumerable<T> GetAll();
    }
}
