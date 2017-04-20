using PesquisaComAjax.Data.Contexto;
using PesquisaComAjax.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data;
using PesquisaComAjax.Data.Interfaces;

namespace PesquisaComAjax.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {

        protected ContextoDb _Db = new ContextoDb();
        
        public void Add(TEntity obj)
        {
            _Db.Set<TEntity>().Add(obj);
            _Db.SaveChanges();
        }
        
        public void Dispose()
        {
            _Db.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _Db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            _Db.Entry(obj).State = EntityState.Deleted;
           _Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _Db.Entry(obj).State = EntityState.Modified;
            _Db.SaveChanges();
        }
    }
}
