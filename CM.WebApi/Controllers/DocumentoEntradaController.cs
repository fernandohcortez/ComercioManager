using CM.Core;
using CM.Domain.BLLs;
using CM.WebApi.Controllers.Base;

namespace CM.WebApi.Controllers
{
    public class DocumentoEntradaController : ControllerBase<DocumentoEntradaDTO, DocumentoEntradaBLL, int>
    {
        public override void Post(DocumentoEntradaDTO documentoEntradaDTO)
        {
            var documentoEntradaBll = new DocumentoEntradaBLL();
            documentoEntradaBll.Incluir(documentoEntradaDTO);
        }
    }
}