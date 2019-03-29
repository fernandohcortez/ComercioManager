using CMDataManager.BLL;
using CMDataManager.Controllers.Base;
using CMDataModel;
using CMDataModel.Repository.Interfaces;

namespace CMDataManager.Controllers
{
    public class ProdutoController : ControllerBase<Produto, IProdutoRepository, int>
    {
        public override void Post(Produto produto)
        {
            var produtoBll = new ProdutoBll(UoW);
            produtoBll.Incluir(produto);
        }
    }
}