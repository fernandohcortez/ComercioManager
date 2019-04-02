using System;
using System.Linq;
using AutoMapper;
using CM.Core;
using CM.DataAccess;

namespace CM.Domain.Mapping
{
    public static class Mapping
    {
        public static IMapper Mapper => AutoMapper.Mapper.Instance;

        static Mapping()
        {
            CreateMap();
        }

        private static void CreateMap()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioDTO>().ReverseMap();
                cfg.CreateMap<Cliente, ClienteDTO>().ReverseMap();
                cfg.CreateMap<Fornecedor, FornecedorDTO>().ReverseMap();
                cfg.CreateMap<Produto, ProdutoDTO>().ReverseMap();
                cfg.CreateMap<Estoque, EstoqueDTO>().ReverseMap();
                cfg.CreateMap<PedidoVenda, PedidoVendaDTO>().ReverseMap();
                cfg.CreateMap<PedidoVendaItem, PedidoVendaItemDTO>().ReverseMap();
                cfg.CreateMap<DocumentoEntrada, DocumentoEntradaDTO>().ReverseMap();
                cfg.CreateMap<DocumentoEntradaItem, DocumentoEntradaItemDTO>().ReverseMap();
            });
        }

        public static Type GetEntityType<T>() 
        {
            return AutoMapper.Mapper.Configuration.GetAllTypeMaps().FirstOrDefault(m => m.DestinationType == typeof(T))?.SourceType;
        }

        public static Type GetDtoType<T>()
        {
            return AutoMapper.Mapper.Configuration.GetAllTypeMaps().FirstOrDefault(m => m.SourceType == typeof(T))?.DestinationType;
        }
    }
}
