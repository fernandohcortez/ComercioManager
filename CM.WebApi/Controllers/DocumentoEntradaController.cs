using System.Threading.Tasks;
using CM.Core;
using CM.Domain.BLLs;
using CM.WebApi.Controllers.Base;

namespace CM.WebApi.Controllers
{
    public class DocumentoEntradaController : ControllerBase<DocumentoEntradaDTO, DocumentoEntradaBLL, int>
    {
        public override async Task<DocumentoEntradaDTO> Post(DocumentoEntradaDTO documentoEntradaDTO)
        {
            var documentoEntradaBll = new DocumentoEntradaBLL();
            return await documentoEntradaBll.IncluirAsync(documentoEntradaDTO);
        }
    }
}