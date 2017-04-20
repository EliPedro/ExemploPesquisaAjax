using PesquisaComAjax.Application.Interfaces;
using PesquisaComAjax.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PesquisaComAjax.Mvc
{
    /// <summary>
    /// Summary description for MyImageHandler
    /// </summary>
    public class MyImageHandler : IHttpHandler
    {
        //private readonly IAppProdutoService _serviceProdutoApp;

        
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            var param = context.Request.QueryString["id"];
            int id = 0;

            if (param != null && int.TryParse(param, out id))
            {
                byte[] foto = null;

                using (var teste = new ProdutoRepository())
                {

                    foto = teste.ObterImagens();
                }

                //Cache
                TimeSpan cacheTime = new TimeSpan(1, 0, 0);
                context.Response.Cache.VaryByParams["*"] = true;
                context.Response.Cache.SetExpires(DateTime.Now.Add(cacheTime));
                context.Response.Cache.SetMaxAge(cacheTime);
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.BinaryWrite(foto);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}