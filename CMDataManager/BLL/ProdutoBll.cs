using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDataManager.BLL.Base;
using CMDataModel;
using CMDataModel.Repository.UnitOfWork;

namespace CMDataManager.BLL
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