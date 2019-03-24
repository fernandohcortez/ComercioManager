using CMDataModel;
using CMDataModel.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace CMDataManager.Controllers
{
    [Authorize]
    public class ProdutoController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoController()
        {
            _unitOfWork = UnitOfWork.CriarInstancia();
        }

        public IEnumerable<Produto> Get()
        {
            return _unitOfWork.Produtos.GetAll();
        }

        public Produto Get(int id)
        {
            return _unitOfWork.Produtos.Get(id);
        }

        public void Post([FromBody]Produto produto)
        {
            _unitOfWork.Produtos.Add(produto);

            _unitOfWork.Commit();
        }

        public void Put(int id, [FromBody]Produto produto)
        {
            _unitOfWork.Produtos.Update(produto);

            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _unitOfWork.Produtos.Remove(id);

            _unitOfWork.Commit();
        }
    }
}