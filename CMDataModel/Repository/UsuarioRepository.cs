using System.Data.Entity;
using CM.DataAccess.Repository.Interfaces;
using CMDataModel.Repository.Base;

namespace CM.DataAccess.Repository
{
    public class UsuarioRepository : Repository<Usuario, CMDataEntities>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context)
        {
        }
    }
}
