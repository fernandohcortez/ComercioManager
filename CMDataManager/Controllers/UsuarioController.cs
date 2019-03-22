using CMDataModel;
using CMDataModel.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace CMDataManager.Controllers
{
    //[Authorize]
    public class UsuarioController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioController()
        {
            _unitOfWork = UnitOfWork.CriarInstancia();
        }

        public IEnumerable<Usuario> Get()
        {
            return _unitOfWork.Usuarios.GetAll();
        }

        //[HttpGet]
        //[Route("api/Usuario/{id:alpha}")]
        public Usuario Get(string id)
        {
            return _unitOfWork.Usuarios.Get(id);
        }

        public void Post([FromBody]Usuario usuario)
        {
            _unitOfWork.Usuarios.Add(usuario);
        }

        public void Put(string id, [FromBody]Usuario usuario)
        {
            _unitOfWork.Usuarios.Update(usuario);
        }

        public void Delete(string id)
        {
            _unitOfWork.Usuarios.Remove(new Usuario { Id = id });
        }
    }
}