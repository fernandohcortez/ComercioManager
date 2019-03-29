using System.Data.Entity;
using CMDataModel.Repository.Base;
using CMDataModel.Repository.Interfaces;

namespace CMDataModel.Repository
{
    public class FornecedorRepository : Repository<Fornecedor, CMDataEntities>, IFornecedorRepository
    {
        public FornecedorRepository(DbContext context) : base(context)
        {
        }
    }
}
