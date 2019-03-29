using System.Data.Entity;
using CM.DataAccess.Repository.Base;
using CM.DataAccess.Repository.Interfaces;

namespace CM.DataAccess.Repository
{
    public class FornecedorRepository : Repository<Fornecedor, CMDataEntities>, IFornecedorRepository
    {
        public FornecedorRepository(DbContext context) : base(context)
        {
        }
    }
}
