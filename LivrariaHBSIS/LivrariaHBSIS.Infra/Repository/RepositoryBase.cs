using LivrariaHBSIS.domain.Interfaces;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LivrariaHBSIS.Infra.Repository
{
    public abstract class RepositoryBase<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly NHContext _nhContext;

        public RepositoryBase()
        {
            _nhContext = new NHContext();
        }
        public void Delete(T obj)
        {
            try
            {
                _nhContext.BeginTransaction();
                _nhContext.Session.Delete(obj);
                _nhContext.Transaction.Commit();
            }
            catch (Exception e)
            {
                _nhContext.Transaction.Rollback();
            }
        }

        public IEnumerable<T> GetAll()
        {
            var registros = _nhContext.Session.Query<T>().ToList();
            return registros;
        }

        public T GetById(long id)
        {
            return _nhContext.Session.Get<T>(id);
        }

        public void Save(T obj)
        {
            try
            {
                _nhContext.BeginTransaction();
                _nhContext.Session.Save(obj);
                _nhContext.Transaction.Commit();
            }
            catch (Exception e)
            {
                _nhContext.Transaction.Rollback();
            }
        }

        public void Update(T obj)
        {
            try
            {
                _nhContext.BeginTransaction();
                _nhContext.Session.Update(obj);
                _nhContext.Transaction.Commit();
            }
            catch (Exception e)
            {
                _nhContext.Transaction.Rollback();
            }
        }
        public void Dispose()
        {
            //_nhContext.Dispose();
        }
    }
}
