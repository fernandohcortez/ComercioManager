using CMDataModel;
using CMDataModel.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace CMDataManager.Controllers
{
    [Authorize]
    public class PedidoVendaItemController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PedidoVendaItemController()
        {
            _unitOfWork = UnitOfWork.CriarInstancia();
        }

        public IEnumerable<PedidoVendaItem> Get()
        {
            return _unitOfWork.ItensPedidoVenda.GetAll();
        }

        public PedidoVendaItem Get(int id)
        {
            return _unitOfWork.ItensPedidoVenda.Get(id);
        }

        public void Post([FromBody]PedidoVendaItem pedidoVendaItem)
        {
            _unitOfWork.ItensPedidoVenda.Add(pedidoVendaItem);
        }

        public void Put(int id, [FromBody]PedidoVendaItem pedidoVendaItem)
        {
            _unitOfWork.ItensPedidoVenda.Update(pedidoVendaItem);
        }

        public void Delete(int id)
        {
            _unitOfWork.ItensPedidoVenda.Remove(id);
        }
    }
}