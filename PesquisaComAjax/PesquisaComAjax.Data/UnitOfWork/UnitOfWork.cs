using PesquisaComAjax.Data.Interfaces;
using System;
using PesquisaComAjax.Domain.Interfaces.Repositories;
using PesquisaComAjax.Data.Contexto;
using PesquisaComAjax.Data.Repositories;

namespace PesquisaComAjax.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        IProdutoRepository _produtoRepository;
        private readonly ContextoDb _Db;
         
        private bool disposedValue = false;
        
        public UnitOfWork()
        {
            _Db = new ContextoDb();
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                if (_produtoRepository == null)
                {
                    _produtoRepository = new ProdutoRepository();
                }

                return _produtoRepository;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _Db.Dispose();
                }
                
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            _Db.SaveChanges();
        }
    }
}
