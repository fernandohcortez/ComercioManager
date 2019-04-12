using CM.Core;
using CM.Domain.BLLs;
using CM.WebApi.Controllers.Base;

namespace CM.WebApi.Controllers
{
    public class PedidoVendaController : ControllerBase<PedidoVendaDTO, PedidoVendaBLL, int>
    {
        public override PedidoVendaDTO Post(PedidoVendaDTO pedidoVendaDTO)
        {
            var pedidoVendaBll = new PedidoVendaBLL();
            return pedidoVendaBll.Incluir(pedidoVendaDTO);
        }
    }
}