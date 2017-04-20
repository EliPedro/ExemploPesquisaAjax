using PesquisaComAjax.Application.Interfaces;
using PesquisaComAjax.Application.RecuperaImagem;
using System.Web;
using System.Web.Routing;

namespace PesquisaComAjax.Mvc.App_Start
{
    public class ImagemRouterHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new ExibirImagem(requestContext);
        }
    }
}