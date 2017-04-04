using PesquisaComAjax.Domain.Entities;
using System.Collections.Generic;

namespace PesquisaComAjax.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> PesquisarPorNome(string nome);

    }
}
