using System.Data.Entity;
using CM.DataAccess.Repository.Base;
using CM.DataAccess.Repository.Interfaces;

namespace CM.DataAccess.Repository
{
    public class ProdutoRepository : Repository<Produto, CMDataEntities>, IProdutoRepository
    {
        public ProdutoRepository(DbContext context) : base(context)
        {
        }
    }
}
