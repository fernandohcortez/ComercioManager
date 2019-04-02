using System.Collections.Generic;
using CM.Core;
using CM.DataAccess;
using CM.Domain.BLLs.Base;

namespace CM.Domain.BLLs
{
    public class UsuarioBLL : BaseBLL<UsuarioDTO>
    {
        public override UsuarioDTO Get(object id)
        {
            return Get<Usuario>(id.ToString());
        }

        public override IEnumerable<UsuarioDTO> GetAll()
        {
            return GetAll<Usuario>();
        }

        public override void Add(UsuarioDTO usuarioDTO)
        {
            Add<Usuario>(usuarioDTO);
        }

        public override void Update(UsuarioDTO usuarioDTO)
        {
            Update<Usuario>(usuarioDTO);
        }

        public override void Remove(object id)
        {
            Remove<Usuario>(id.ToString());
        }
    }
}
