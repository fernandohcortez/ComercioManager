using CMDataModel;
using CMDataModel.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;
using CMDataManager.Controllers.Base;
using CMDataModel.Repository.Interfaces;

namespace CMDataManager.Controllers
{
    public class EstoqueController : ControllerBase<Estoque, IEstoqueRepository, int>
    {
        
    }
}