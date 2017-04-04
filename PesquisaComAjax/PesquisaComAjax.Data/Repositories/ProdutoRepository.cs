using System;
using System.Collections.Generic;
using PesquisaComAjax.Domain.Entities;
using PesquisaComAjax.Domain.Interfaces.Repositories;
using System.Linq;

namespace PesquisaComAjax.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> PesquisarPorNome(string nome)
        {
            return db.Produtos.Where(p => p.Nome == nome);
        }
    }
}
