using CM.DataAccess;
using CM.DataAccess.Repository.Interfaces;
using CM.WebApi.BLL;
using CM.WebApi.Controllers.Base;

namespace CM.WebApi.Controllers
{
    public class PedidoVendaController : ControllerBase<PedidoVenda, IPedidoVendaRepository, int>
    {
        public override void Post(PedidoVenda pedidoVenda)
        {
            var pedidoVendaBll = new PedidoVendaBll(UoW);
            pedidoVendaBll.Incluir(pedidoVenda);
        }
    }
}