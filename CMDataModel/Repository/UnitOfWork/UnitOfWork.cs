using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CMDataModel.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CMDataEntities _context;

        public IUsuarioRepository Usuarios { get; }
        public IProdutoRepository Produtos { get; }

        public static UnitOfWork CriarInstancia()
        {
            return new UnitOfWork(new CMDataEntities());
        }

        public UnitOfWork(CMDataEntities context)
        {
            _context = context;

            Usuarios = new UsuarioRepository(_context);
            Produtos = new ProdutoRepository(_context);
        }

        public int Commit()
        {
            return _context?.SaveChanges() ?? 0;
        }

        public async Task<int> CommitAsync()
        {
            if (_context == null)
                return 0;

            return await _context?.SaveChangesAsync();
        }

        public void Rollback()
        {
            foreach (var entry in _context.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
