using System.Threading.Tasks;
using CMDesktopUI.Models;

namespace CMDesktopUI.Helpers
{
    public interface IApiHelper
    {
        Task<UsuarioAutenticado> Autenticar(string usuario, string senha);
        Task IncluirProduto(string nome, string descricao, decimal precoVenda);
    }
}