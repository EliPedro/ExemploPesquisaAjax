using System;
using System.Collections.Generic;
using PesquisaComAjax.Application.Interfaces;
using PesquisaComAjax.Domain.Entities;
using PesquisaComAjax.Domain.Interfaces.Services;

namespace PesquisaComAjax.Application
{
    public class ProdutoAppService : AppServiceBase<Produto>, IAppProdutoService
    {
        private readonly IProdutoService _service;

        public ProdutoAppService(IProdutoService service) : base(service)
        {
            _service = service;
        }

        public IEnumerable<Produto> PesquisarPorNome(string nome)
        {
            return _service.PesquisarPorNome(nome);
        }
    }
}
