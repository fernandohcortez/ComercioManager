using CM.DataAccess;
using CM.DataAccess.Repository.UnitOfWork;
using CM.WebApi;
using CM.WebApi.BLL.Base;

namespace CM.WebApi.BLL
{
    public class PedidoVendaBll : BllBase
    {
        public PedidoVendaBll(IUnitOfWork uoW) : base(uoW)
        {

        }

        public void Incluir(PedidoVenda pedidoVenda)
        {
            UoW.PedidosVenda.Add(pedidoVenda);

            var estoqueBll = new EstoqueBll(UoW);

            foreach (var item in pedidoVenda.Itens)
            {
                estoqueBll.MovimentarEstoque(TipoMovimentoEstoque.Saida, item.Produto, item.Quantidade, item.ValorUnitario);
            }

            UoW.Commit();
        }
    }
}