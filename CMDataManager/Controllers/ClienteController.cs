using CM.DataAccess;
using CM.DataAccess.Repository.Interfaces;
using CM.WebApi.Controllers.Base;

namespace CM.WebApi.Controllers
{
    public class ClienteController : ControllerBase<Cliente, IClienteRepository, int>
    {
    }
}