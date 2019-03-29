using System.Data.Entity;
using CM.DataAccess.Repository.Interfaces;
using CMDataModel.Repository.Base;

namespace CM.DataAccess.Repository
{
    public class FornecedorRepository : Repository<Fornecedor, CMDataEntities>, IFornecedorRepository
    {
        public FornecedorRepository(DbContext context) : base(context)
        {
        }
    }
}
