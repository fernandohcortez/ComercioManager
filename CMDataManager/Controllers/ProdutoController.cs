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

        // GET api/values
        public IEnumerable<Produto> Get()
        {
            return _unitOfWork.Produtos.GetAll();
        }

        // GET api/values/5
        public Produto Get(int id)
        {
            return _unitOfWork.Produtos.Get(id);
        }

        // POST api/values
        public void Post([FromBody]Produto produto)
        {
            _unitOfWork.Produtos.Add(produto);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Produto produto)
        {
            _unitOfWork.Produtos.Update(produto);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _unitOfWork.Produtos.Remove(new Produto { Id = id });
        }
    }
}