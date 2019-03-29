using CMDataManager.Controllers.Base;
using CMDataModel;
using CMDataModel.Repository.Interfaces;
using CMDataModel.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Net.Mime;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace CMDataManager.Controllers
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