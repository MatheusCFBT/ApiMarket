using AutoMapper;
using DevApi.ViewModels;
using DevBusiness.Models;

namespace DevApi.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<ProdutoViewModel, Produto >();

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeFornecedor, options => options.MapFrom(src => src.Fornecedor.Nome));

        }
    }
}
