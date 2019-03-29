using CM.DataAccess;
using CM.DataAccess.Repository.UnitOfWork;
using CM.WebApi.BLL.Base;

namespace CM.WebApi.BLL
{
    public class ProdutoBll : BllBase
    {
        public ProdutoBll(IUnitOfWork uoW) : base(uoW)
        {

        }

        public void Incluir(Produto produto)
        {
            UoW.Produtos.Add(produto);

            var estoqueBll = new EstoqueBll(UoW);
            estoqueBll.IncluirEstoqueInicial(produto);

            UoW.Commit();
        }
    }
}