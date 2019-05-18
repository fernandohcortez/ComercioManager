using System.Threading.Tasks;
using CM.Core;
using CM.Domain.BLLs;
using CM.WebApi.Controllers.Base;

namespace CM.WebApi.Controllers
{
    public class PedidoVendaController : ControllerBase<PedidoVendaDTO, PedidoVendaBLL, int>
    {
        public override async Task<PedidoVendaDTO> Post(PedidoVendaDTO pedidoVendaDTO)
        {
            var pedidoVendaBll = new PedidoVendaBLL();
            return await pedidoVendaBll.IncluirAsync(pedidoVendaDTO);
        }
    }
}