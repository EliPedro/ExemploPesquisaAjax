using PesquisaComAjax.Application.Interfaces;
using PesquisaComAjax.Data.Repositories;
using System;
using System.Web;
using System.Web.Routing;

//Manipulador de arquivos
namespace PesquisaComAjax.Application.RecuperaImagem
{
    public class ExibirImagem : IHttpHandler
    {
        //private readonly IAppProdutoService _serviceProdutoApp;

        //public ExibirImagem(IAppProdutoService serviceProdutoApp)
        //{
        //    _serviceProdutoApp = serviceProdutoApp;

        //}

        public ExibirImagem(RequestContext reqcon)
        {
            RequestContext = reqcon;
        }

        public RequestContext RequestContext { get; set; }

        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "image/jpeg";

            byte[] foto = null;
            var produtoRepository = new ProdutoRepository();
            foto = produtoRepository.ObterImagens();
            context.Response.BinaryWrite(foto);

            //context.Response.Write("Hello");
        }

        #endregion
    }
}
