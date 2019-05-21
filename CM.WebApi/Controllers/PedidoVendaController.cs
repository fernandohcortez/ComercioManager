using System;
using System.Threading.Tasks;
using System.Web.Http;
using CM.Core;
using CM.Domain.BLLs;
using CM.WebApi.Controllers.Base;

namespace CM.WebApi.Controllers
{
    public class PedidoVendaController : ControllerBase<PedidoVendaDTO, PedidoVendaBLL, int>
    {
        public override async Task<IHttpActionResult> Post(PedidoVendaDTO pedidoVendaDTO)
        {
            var pedidoVendaBll = new PedidoVendaBLL();

            try
            {
                return Ok(await pedidoVendaBll.IncluirAsync(pedidoVendaDTO));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}