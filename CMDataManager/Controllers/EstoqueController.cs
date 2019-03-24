using CMDataModel;
using CMDataModel.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace CMDataManager.Controllers
{
    [Authorize]
    public class EstoqueController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstoqueController()
        {
            _unitOfWork = UnitOfWork.CriarInstancia();
        }

        public IEnumerable<Estoque> Get()
        {
            return _unitOfWork.Estoque.GetAll();
        }

        public Estoque Get(int id)
        {
            return _unitOfWork.Estoque.Get(id);
        }

        public void Post([FromBody]Estoque estoque)
        {
            _unitOfWork.Estoque.Add(estoque);
        }

        public void Put(int id, [FromBody]Estoque estoque)
        {
            _unitOfWork.Estoque.Update(estoque);
        }

        public void Delete(int id)
        {
            _unitOfWork.Estoque.Remove(id);
        }
    }
}