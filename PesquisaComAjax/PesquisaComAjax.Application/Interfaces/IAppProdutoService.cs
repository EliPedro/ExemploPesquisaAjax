using PesquisaComAjax.Domain.Entities;
using System.Collections.Generic;

namespace PesquisaComAjax.Application.Interfaces
{
    public interface IAppProdutoService : IAppServiceBase<Produto>
    {
        IEnumerable<Produto> PesquisarPorNome(string nome);

    }
}
