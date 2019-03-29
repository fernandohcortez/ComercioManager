using CMDataManager.BLL.Base;
using CMDataModel;
using CMDataModel.Repository.UnitOfWork;

namespace CMDataManager.BLL
{
    public class DocumentoEntradaBll : BllBase
    {
        public DocumentoEntradaBll(IUnitOfWork uoW) : base(uoW)
        {

        }

        public void Incluir(DocumentoEntrada documentoEntrada)
        {
            UoW.DocumentosEntrada.Add(documentoEntrada);

            var estoqueBll = new EstoqueBll(UoW);

            foreach (var item in documentoEntrada.Itens)
            {
                estoqueBll.MovimentarEstoque(TipoMovimentoEstoque.Entrada, item.Produto, item.Quantidade, item.ValorUnitario);
            }          
           
            UoW.Commit();
        }
    }
}