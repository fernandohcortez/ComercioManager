using System.Threading.Tasks;
using CMDesktopUI.Models;

namespace CMDesktopUI.Helpers
{
    public interface IApiHelper
    {
        Task<UsuarioAutenticado> Autenticar(string usuario, string senha);
    }
}