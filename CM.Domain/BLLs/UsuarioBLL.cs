using System.Collections.Generic;
using System.Threading.Tasks;
using CM.Core;
using CM.DataAccess;
using CM.Domain.BLLs.Base;

namespace CM.Domain.BLLs
{
    public class UsuarioBLL : BaseBLL<UsuarioDTO>
    {
        public override async Task<UsuarioDTO> GetAsync(object id)
        {
            return await GetAsync<Usuario>(id.ToString());
        }

        public override async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            return await GetAllAsync<Usuario>();
        }

        public override async Task<UsuarioDTO> AddAsync(UsuarioDTO usuarioDTO)
        {
            return await AddAsync<Usuario>(usuarioDTO, true);
        }

        public override async Task UpdateAsync(UsuarioDTO usuarioDTO)
        {
            await UpdateAsync<Usuario>(usuarioDTO, true);
        }

        public override async Task RemoveAsync(object id)
        {
            await RemoveAsync<Usuario>(id.ToString(), true);
        }
    }
}
