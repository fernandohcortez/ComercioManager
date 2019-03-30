using CM.Core;
using CM.Domain;
using CM.Domain.BLL;
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