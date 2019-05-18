using CM.Core.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CM.Domain.BLLs.Base;

namespace CM.WebApi.Controllers.Base
{
    [Authorize]
    public class ControllerBase<TDTO, TBLL, TIdType> : ApiController
        where TDTO : class, IBaseDTO
        where TBLL : class, IBaseBLL<TDTO>
    {
        protected TBLL BLL { get; }

        public ControllerBase()
        {
            BLL = Activator.CreateInstance<TBLL>();
        }

        public virtual async Task<IEnumerable<TDTO>> Get()
        {
            return await BLL.GetAllAsync();
        }

        public virtual async Task<TDTO> Get(TIdType id)
        {
            return await BLL.GetAsync(id);
        }

        public virtual async Task<TDTO> Post(TDTO dto)
        {
            return await BLL.AddAsync(dto);
        }

        public virtual async Task<TDTO> Put(TIdType id, [FromBody]TDTO dto)
        {
            await BLL.UpdateAsync(dto);

            return dto;
        }

        public virtual async Task Delete(TIdType id)
        {
            await BLL.RemoveAsync(id);
        }
    }
}