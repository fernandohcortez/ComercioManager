using CMDataModel;
using CMDataModel.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace CMDataManager.Controllers
{
    [Authorize]
    public class PedidoVendaController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PedidoVendaController()
        {
            _unitOfWork = UnitOfWork.CriarInstancia();
        }

        public IEnumerable<PedidoVenda> Get()
        {
            return _unitOfWork.PedidosVenda.GetAll();
        }

        public PedidoVenda Get(int id)
        {
            return _unitOfWork.PedidosVenda.Get(id);
        }

        public void Post([FromBody]PedidoVenda pedidoVenda)
        {
            _unitOfWork.PedidosVenda.Add(pedidoVenda);
        }

        public void Put(int id, [FromBody]PedidoVenda pedidoVenda)
        {
            _unitOfWork.PedidosVenda.Update(pedidoVenda);
        }

        public void Delete(int id)
        {
            _unitOfWork.PedidosVenda.Remove(id);
        }
    }
}