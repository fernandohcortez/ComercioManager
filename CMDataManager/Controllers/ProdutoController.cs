using CM.DataAccess;
using CM.DataAccess.Repository.Interfaces;
using CM.WebApi.BLL;
using CM.WebApi.Controllers.Base;

namespace CM.WebApi.Controllers
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