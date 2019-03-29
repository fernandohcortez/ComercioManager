using CM.DataAccess;
using CM.DataAccess.Repository.UnitOfWork;
using CM.WebApi;
using CM.WebApi.BLL;
using CM.WebApi.BLL.Base;

namespace CM.WebApi.BLL
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