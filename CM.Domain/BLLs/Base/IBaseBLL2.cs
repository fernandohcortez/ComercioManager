using CM.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CM.Domain.BLLs.Base
{
    public interface IBaseBLL<TDTO> where TDTO : IBaseDTO
    {
        Task<TDTO> AddAsync(TDTO dto);
        Task<TDTO> GetAsync(object id);
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task RemoveAsync(object id);
        Task UpdateAsync(TDTO dto);
    }
}