using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using CMDesktopUI.Models;

namespace CMDesktopUI.Helpers
{
    public interface IApiHelper
    {
        Task<UsuarioAutenticado> Autenticar(string usuario, string senha);
        Task IncluirCliente();
        Task IncluirFornecedor();
        Task IncluirProduto(string nome, string descricao, decimal precoVenda);
        Task IncluirDocumentoEntrada();
        Task IncluirPedidoVenda();
        Task<List<Produto>> ListarProdutos();
    }
}