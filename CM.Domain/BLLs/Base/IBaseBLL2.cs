using System.Collections.Generic;
using CM.Core.Base;

namespace CM.Domain.BLLs.Base
{
    public interface IBaseBLL<TDTO> where TDTO : IBaseDTO
    {
        void Add(TDTO dto);
        TDTO Get(object id);
        IEnumerable<TDTO> GetAll();
        void Remove(object id);
        void Update(TDTO dto);
    }
}