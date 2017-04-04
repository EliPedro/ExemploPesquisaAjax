using AutoMapper;
using PesquisaComAjax.Domain.Entities;
using PesquisaComAjax.Mvc.ViewModels;

namespace PesquisaComAjax.Mvc.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>();
        }
    }
}