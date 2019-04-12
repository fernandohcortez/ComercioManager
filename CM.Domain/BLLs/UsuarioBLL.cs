﻿using System.Collections.Generic;
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

        public override UsuarioDTO Add(UsuarioDTO usuarioDTO)
        {
            return Add<Usuario>(usuarioDTO, true);
        }

        public override void Update(UsuarioDTO usuarioDTO)
        {
            Update<Usuario>(usuarioDTO, true);
        }

        public override void Remove(object id)
        {
            Remove<Usuario>(id.ToString(), true);
        }
    }
}
