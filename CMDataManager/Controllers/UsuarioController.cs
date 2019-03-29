using System.Web.Http;
using CM.DataAccess;
using CM.DataAccess.Repository.Interfaces;
using CM.WebApi.Controllers.Base;
using Microsoft.AspNet.Identity;

namespace CM.WebApi.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ControllerBase<Usuario, IUsuarioRepository, string>
    {
        [Route("GetUsuarioCorrente")]
        public Usuario GetUsuarioCorrente()
        {
            return Repository.Get(RequestContext.Principal.Identity.GetUserId());
        }
    }
}