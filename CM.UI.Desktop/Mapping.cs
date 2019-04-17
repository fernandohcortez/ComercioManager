using AutoMapper;
using CM.UI.Model.Models.Base;
using System.Linq;

namespace CM.UI.Desktop
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
                typeof(ModelBase).Assembly.GetTypes()
                    .Where(type => type.IsClass)
                    .Where(type => type.Name.EndsWith("Model"))
                    .ToList()
                    .ForEach(t => cfg.CreateMap(t, t));
            });
        }
    }
}
