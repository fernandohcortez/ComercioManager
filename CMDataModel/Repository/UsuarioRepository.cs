using System.Data.Entity;
using CM.DataAccess.Repository.Base;
using CM.DataAccess.Repository.Interfaces;

namespace CM.DataAccess.Repository
{
    public class UsuarioRepository : Repository<Usuario, CMDataEntities>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context)
        {
        }
    }
}
