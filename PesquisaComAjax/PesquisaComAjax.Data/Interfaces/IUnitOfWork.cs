using PesquisaComAjax.Domain.Interfaces.Repositories;
using System;

namespace PesquisaComAjax.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProdutoRepository ProdutoRepository { get;}
        void Commit();
    }
}
