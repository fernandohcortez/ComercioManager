using AutoMapper;
using CM.UI.Desktop.ViewModels;
using CM.UI.Model.Models;

namespace CM.UI.Desktop.Mapping
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
                cfg.CreateMap<ProdutoViewModel, ProdutoModel>().ReverseMap();
            });
        }
    }
}
