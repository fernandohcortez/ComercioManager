using CM.UI.Model.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CM.UI.Model.Helpers
{
    public interface IApiHelper
    {
        Task<AutenticarUsuario> Autenticar(string usuario, string senha);
        Task ObterInfoUsuarioLogado(string token);
        
        Task<T> Incluir<T>(T model, string nomeUri = null);
        Task<T> Alterar<T>(T model, object id, string nomeUri = null);
        Task Remover<T>(object id, string nomeUri = null);
        Task<ObservableCollection<T>> Listar<T>(string nomeUri = null);
        Task<T> Obter<T>(object id, string nomeUri = null);
        
        Task IncluirCliente();
        Task IncluirDocumentoEntrada();
        Task IncluirFornecedor();
        Task IncluirPedidoVenda();

        Task<ProdutoModel> IncluirProduto(ProdutoModel produtoModel);
        Task<ProdutoModel> AlterarProduto(ProdutoModel produtoModel);
        Task RemoverProduto(ProdutoModel produtoModel);
        Task<ObservableCollection<ProdutoModel>> ListarProdutos();
        Task<ProdutoModel> ObterProduto(int id);
    }
}