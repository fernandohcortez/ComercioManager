using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Caliburn.Micro;
using CM.UI.Model.Models;

namespace CM.UI.Model.Helpers
{
    public interface IApiHelper
    {
        Task<AutenticarUsuario> Autenticar(string usuario, string senha);
        Task ObterInfoUsuarioLogado(string token);
        Task IncluirCliente();
        Task IncluirFornecedor();
        Task<ProdutoModel> IncluirProduto(ProdutoModel produtoModel);
        Task<ProdutoModel> AlterarProduto(ProdutoModel produtoModel);
        Task RemoverProduto(ProdutoModel produtoModel);
        Task<ProdutoModel> ObterProduto(int id);
        Task IncluirDocumentoEntrada();
        Task IncluirPedidoVenda();
        Task<ObservableCollection<ProdutoModel>> ListarProdutos();
    }
}