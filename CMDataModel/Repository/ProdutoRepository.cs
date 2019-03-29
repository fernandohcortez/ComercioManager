using System.Data.Entity;
using CM.DataAccess.Repository.Interfaces;
using CMDataModel.Repository.Base;

namespace CM.DataAccess.Repository
{
    public class ProdutoRepository : Repository<Produto, CMDataEntities>, IProdutoRepository
    {
        public ProdutoRepository(DbContext context) : base(context)
        {
        }
    }
}
