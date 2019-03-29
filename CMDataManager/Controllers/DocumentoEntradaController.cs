using CM.DataAccess;
using CM.DataAccess.Repository.Interfaces;
using CM.WebApi.BLL;
using CM.WebApi.Controllers.Base;

namespace CM.WebApi.Controllers
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