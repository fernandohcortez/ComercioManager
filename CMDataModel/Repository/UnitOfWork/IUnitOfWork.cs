using System;
using System.Threading.Tasks;
using CM.DataAccess.Repository.Interfaces;

namespace CM.DataAccess.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IClienteRepository Clientes { get; }
        IFornecedorRepository Fornecedores { get; }
        IProdutoRepository Produtos { get; }
        IDocumentoEntradaRepository DocumentosEntrada { get; }
        IDocumentoEntradaItemRepository ItensDocumentoEntrada { get; }
        IPedidoVendaRepository PedidosVenda { get; }
        IPedidoVendaItemRepository ItensPedidoVenda { get; }
        IEstoqueRepository Estoque { get; }

        int Commit();
        Task<int> CommitAsync();
        void Rollback();
    }
}
