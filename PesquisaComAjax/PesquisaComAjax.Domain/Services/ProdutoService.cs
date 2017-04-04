using System;
using System.Collections.Generic;
using PesquisaComAjax.Domain.Entities;
using PesquisaComAjax.Domain.Interfaces.Repositories;
using PesquisaComAjax.Domain.Interfaces.Services;

namespace PesquisaComAjax.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>,IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Produto> PesquisarPorNome(string nome)
        {
            return _repository.PesquisarPorNome(nome);
        }
    }
}
