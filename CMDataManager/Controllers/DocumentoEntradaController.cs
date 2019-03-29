using CMDataManager.BLL;
using CMDataManager.Controllers.Base;
using CMDataModel;
using CMDataModel.Repository.Interfaces;

namespace CMDataManager.Controllers
{
    public class DocumentoEntradaController : ControllerBase<DocumentoEntrada, IDocumentoEntradaRepository, int>
    {
        public override void Post(DocumentoEntrada documentoEntrada)
        {
            var documentoEntradaBll = new DocumentoEntradaBll(UoW);
            documentoEntradaBll.Incluir(documentoEntrada);
        }
    }
}