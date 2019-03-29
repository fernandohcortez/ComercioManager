using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CM.DataAccess
{
    public class ContextHelper
    {
        public static ContextHelper CriarInstancia()
        {
            return new ContextHelper(new CMDataEntities());
        }

        private readonly DbContext _context;

        public DbSetHelper DbSet { get; }

        public ContextHelper(DbContext context)
        {
            _context = context;

            DbSet = new DbSetHelper(_context);
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
