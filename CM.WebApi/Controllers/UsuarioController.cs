using System.Web.Http;
using CM.Core;
using CM.Domain.BLLs;
using CM.WebApi.Controllers.Base;
using Microsoft.AspNet.Identity;

namespace CM.WebApi.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ControllerBase<UsuarioDTO, UsuarioBLL, string>
    {
        [Route("GetUsuarioCorrente")]
        public UsuarioDTO GetUsuarioCorrente()
        {
            return BLL.Get(RequestContext.Principal.Identity.GetUserId());
        }
    }
}