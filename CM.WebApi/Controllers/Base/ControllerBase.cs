using CM.Core.Base;
using CM.Domain.BLLs.Base;
using System;
using System.Threading.Tasks;
using System.Web.Http;

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

        public virtual async Task<IHttpActionResult> Get()
        {
            try
            {
                return Ok(await BLL.GetAllAsync());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public virtual async Task<IHttpActionResult> Get(TIdType id)
        {
            try
            {
                return Ok(await BLL.GetAsync(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public virtual async Task<IHttpActionResult> Post(TDTO dto)
        {
            try
            {
                return Ok(await BLL.AddAsync(dto));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public virtual async Task<IHttpActionResult> Put(TIdType id, [FromBody]TDTO dto)
        {
            try
            {
                await BLL.UpdateAsync(dto);

                return Ok(dto);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public virtual async Task<IHttpActionResult> Delete(TIdType id)
        {
            try
            {
                await BLL.RemoveAsync(id);

                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}