using CMDataModel.Repository.Base;
using CMDataModel.Repository.Interfaces;

namespace CMDataModel.Repository.UnitOfWork
{
    public class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        public IUsuarioRepository Usuarios { get; }
        public IProdutoRepository Produtos { get; }
        public IPedidoVendaRepository PedidosVenda { get; }
        public IPedidoVendaItemRepository ItensPedidoVenda { get; }
        public IEstoqueRepository Estoque { get; }

        public UnitOfWork(CMDataEntities context)
        {
            Context = context;

            Usuarios = new UsuarioRepository(Context);
            Produtos = new ProdutoRepository(Context);
            PedidosVenda = new PedidoVendaRepository(Context);
            ItensPedidoVenda = new PedidoVendaItemRepository(Context);
            Estoque = new EstoqueRepository(Context);
        }

        public static UnitOfWork CriarInstancia()
        {
            return new UnitOfWork(new CMDataEntities());
        }
    }
}
