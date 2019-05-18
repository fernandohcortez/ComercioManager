using System.Collections.Generic;
using System.Threading.Tasks;
using CM.Core;
using CM.DataAccess;
using CM.Domain.BLLs.Base;
using CM.Domain.Helpers;
using Helpers;

namespace CM.Domain.BLLs
{
    public class FornecedorBLL : BaseBLL<FornecedorDTO>
    {
        public override async Task<FornecedorDTO> GetAsync(object id)
        {
            return await GetAsync<Fornecedor>(id.IsNullOrEmptyThenZero());
        }

        public override async Task<IEnumerable<FornecedorDTO>> GetAllAsync()
        {
            return await GetAllAsync<Fornecedor>();
        }

        public override async Task<FornecedorDTO> AddAsync(FornecedorDTO dto)
        {
            return await AddAsync<Fornecedor>(dto, true);
        }

        public override async Task UpdateAsync(FornecedorDTO dto)
        {
            await UpdateAsync<Fornecedor>(dto, true);
        }

        public override async Task RemoveAsync(object id)
        {
            await RemoveAsync<Fornecedor>(id.IsNullOrEmptyThenZero(), true);
        }
    }
}
