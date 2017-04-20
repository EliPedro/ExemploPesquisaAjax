using PesquisaComAjax.Domain.Entities;
using System.Collections.Generic;

namespace PesquisaComAjax.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> PesquisarPorNome(string nome);
        byte[] ObterImagens();
    }
}
