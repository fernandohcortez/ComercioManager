using System.Data.Entity;
using CMDataModel.Repository.Base;

namespace CMDataModel.Repository
{
    public class UsuarioRepository : Repository<Usuario, CMDataEntities>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context)
        {
        }
    }
}
