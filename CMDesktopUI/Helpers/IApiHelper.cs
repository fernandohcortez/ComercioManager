using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using CM.Core;
using CMDesktopUI.Models;
using CMDesktopUI.ViewModels;

namespace CMDesktopUI.Helpers
{
    public interface IApiHelper
    {
        Task<UsuarioAutenticado> Autenticar(string usuario, string senha);
        Task IncluirCliente();
        Task IncluirFornecedor();
        Task IncluirProduto(ProdutoViewModel produtoViewModel);
        Task IncluirDocumentoEntrada();
        Task IncluirPedidoVenda();
        Task<List<Produto>> ListarProdutos();
    }
}