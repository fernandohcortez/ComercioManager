using System.Collections.Generic;
using System.Threading.Tasks;
using CM.UI.Model.Models;

namespace CM.UI.Model.Helpers
{
    public interface IApiHelper
    {
        Task<AutenticarUsuario> Autenticar(string usuario, string senha);
        Task ObterInfoUsuarioLogado(string token);
        Task IncluirCliente();
        Task IncluirFornecedor();
        Task IncluirProduto(ProdutoModel produtoModel);
        Task IncluirDocumentoEntrada();
        Task IncluirPedidoVenda();
        Task<List<ProdutoModel>> ListarProdutos();
    }
}