using CM.Core;
using CM.DataAccess;
using CM.Domain.BLLs.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using CM.Domain.Helpers;
using Helpers;

namespace CM.Domain.BLLs
{
    public class ClienteBLL : BaseBLL<ClienteDTO>
    {
        public override async Task<ClienteDTO> GetAsync(object id)
        {
            return await GetAsync<Cliente>(id.IsNullOrEmptyThenZero());
        }

        public override async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            return await GetAllAsync<Cliente>();
        }

        public override async Task<ClienteDTO> AddAsync(ClienteDTO dto)
        {
            return await AddAsync<Cliente>(dto, true);
        }

        public override async Task UpdateAsync(ClienteDTO dto)
        {
            await UpdateAsync<Cliente>(dto, true);
        }

        public override async Task RemoveAsync(object id)
        {
            await RemoveAsync<Cliente>(id.IsNullOrEmptyThenZero(), true);
        }
    }
}
