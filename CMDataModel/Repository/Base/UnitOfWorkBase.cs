using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CM.DataAccess.Repository.Base
{
    public class UnitOfWorkBase
    {
        protected CMDataEntities Context;

        public int Commit()
        {
            return Context?.SaveChanges() ?? 0;
        }

        public async Task<int> CommitAsync()
        {
            if (Context == null)
                return 0;

            return await Context?.SaveChangesAsync();
        }

        public void Rollback()
        {
            foreach (var entry in Context.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged))
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
            Context?.Dispose();
        }
    }
}
