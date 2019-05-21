using CM.Core;
using CM.Domain.BLLs;
using CM.WebApi.Controllers.Base;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CM.WebApi.Controllers
{
    public class DocumentoEntradaController : ControllerBase<DocumentoEntradaDTO, DocumentoEntradaBLL, int>
    {
        public override async Task<IHttpActionResult> Post(DocumentoEntradaDTO documentoEntradaDTO)
        {
            var documentoEntradaBll = new DocumentoEntradaBLL();

            try
            {
                return Ok(await documentoEntradaBll.IncluirAsync(documentoEntradaDTO));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}