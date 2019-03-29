using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDataManager.BLL.Base;
using CMDataModel;
using CMDataModel.Repository.UnitOfWork;

namespace CMDataManager.BLL
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