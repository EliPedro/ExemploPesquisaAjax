using PesquisaComAjax.Application.Interfaces;
using PesquisaComAjax.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace PesquisaComAjax.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _service;

        public AppServiceBase(IServiceBase<TEntity> service)
        {
            _service = service;
        }

        public void Add(TEntity obj)
        {
            _service.Add(obj);
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _service.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _service.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _service.Update(obj);
        }
    }
}
