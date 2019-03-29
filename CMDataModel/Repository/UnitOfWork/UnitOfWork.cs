using CM.DataAccess.Repository.Base;
using CM.DataAccess.Repository.Interfaces;
using CMDataModel.Repository;

namespace CM.DataAccess.Repository.UnitOfWork
{
    public class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        public IUsuarioRepository Usuarios { get; }
        public IClienteRepository Clientes { get; }
        public IFornecedorRepository Fornecedores { get; }
        public IProdutoRepository Produtos { get; }
        public IDocumentoEntradaRepository DocumentosEntrada { get; }
        public IDocumentoEntradaItemRepository ItensDocumentoEntrada { get; }
        public IPedidoVendaRepository PedidosVenda { get; }
        public IPedidoVendaItemRepository ItensPedidoVenda { get; }
        public IEstoqueRepository Estoque { get; }

        public UnitOfWork(CMDataEntities context)
        {
            Context = context;

            Usuarios = new UsuarioRepository(Context);
            Clientes = new ClienteRepository(Context);
            Fornecedores = new FornecedorRepository(Context);
            Produtos = new ProdutoRepository(Context);
            DocumentosEntrada = new DocumentoEntradaRepository(Context);
            ItensDocumentoEntrada = new DocumentoEntradaItemRepository(Context);
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
