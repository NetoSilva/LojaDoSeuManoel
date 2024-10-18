using AutoMapper;
using LojaDoSeuManoel.Application.Results;
using LojaDoSeuManoel.Domain.Models;
using PedidosAPI.Requests;
using PedidosAPI.Responses;

namespace PedidosAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PedidoDTO, Pedido>()
                .ForMember(dest => dest.IdPedido, map => map.MapFrom(src => src.PedidoId))
                .ForMember(dest => dest.Produtos, map => map.MapFrom(src => src.ProdutosDTO))
                .ReverseMap();

            CreateMap<ProdutoDTO, Produto>()
                .ForMember(dest => dest.IdProduto, map => map.MapFrom(src => src.ProdutoId))
                .ForMember(dest => dest.Dimensao, map => map.MapFrom(src => src.DimensaoDTO))
                .ReverseMap();

            CreateMap<DimensoesDTO, Dimensao>()
                .ForMember(dest => dest.Altura, map => map.MapFrom(src => src.Altura))
                .ForMember(dest => dest.Largura, map => map.MapFrom(src => src.Largura))
                .ForMember(dest => dest.Comprimento, map => map.MapFrom(src => src.Comprimento))
                .ReverseMap();
        }
    }
}
