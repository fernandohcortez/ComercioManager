using CMDataManager.Controllers.Base;
using CMDataModel;
using CMDataModel.Repository.Interfaces;
using CMDataModel.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace CMDataManager.Controllers
{
    public class DocumentoEntradaItemController : ControllerBase<DocumentoEntradaItem, IDocumentoEntradaItemRepository, int>
    {
    }
}