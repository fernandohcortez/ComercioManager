using CMDataModel;
using CMDataModel.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;
using CMDataManager.BLL;
using CMDataManager.Controllers.Base;
using CMDataModel.Repository.Interfaces;

namespace CMDataManager.Controllers
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