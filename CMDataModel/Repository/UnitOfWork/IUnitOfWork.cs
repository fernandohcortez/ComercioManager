using System;
using System.Threading.Tasks;
using CMDataModel.Repository.Interfaces;

namespace CMDataModel.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IProdutoRepository Produtos { get; }
        IPedidoVendaRepository PedidosVenda { get; }
        IPedidoVendaItemRepository ItensPedidoVenda { get; }
        IEstoqueRepository Estoque { get; }

        int Commit();
        Task<int> CommitAsync();
        void Rollback();
    }
}
