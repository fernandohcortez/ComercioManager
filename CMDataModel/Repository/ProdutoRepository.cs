using System.Data.Entity;
using CMDataModel.Repository.Base;

namespace CMDataModel.Repository
{
    public class ProdutoRepository : Repository<Produto, CMDataEntities>, IProdutoRepository
    {
        public ProdutoRepository(DbContext context) : base(context)
        {
        }
    }
}
