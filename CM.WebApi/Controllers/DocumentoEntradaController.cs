using CM.Core;
using CM.Domain.BLLs;
using CM.WebApi.Controllers.Base;

namespace CM.WebApi.Controllers
{
    public class DocumentoEntradaController : ControllerBase<DocumentoEntradaDTO, DocumentoEntradaBLL, int>
    {
        public override DocumentoEntradaDTO Post(DocumentoEntradaDTO documentoEntradaDTO)
        {
            var documentoEntradaBll = new DocumentoEntradaBLL();
            return documentoEntradaBll.Incluir(documentoEntradaDTO);
        }
    }
}