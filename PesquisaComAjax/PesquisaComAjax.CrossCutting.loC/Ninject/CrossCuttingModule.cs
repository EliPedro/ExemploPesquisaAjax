using Ninject;
using PesquisaComAjax.Application;
using PesquisaComAjax.Application.Interfaces;
using PesquisaComAjax.Data.Repositories;
using PesquisaComAjax.Domain.Interfaces.Repositories;
using PesquisaComAjax.Domain.Interfaces.Services;
using PesquisaComAjax.Domain.Services;

namespace PesquisaComAjax.CrossCutting.loC.Ninject
{
    public class CrossCuttingModule
    {
        public void AddBiding(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IAppProdutoService>().To<ProdutoAppService>();
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IProdutoService>().To<ProdutoService>();
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
        }

    }
}
