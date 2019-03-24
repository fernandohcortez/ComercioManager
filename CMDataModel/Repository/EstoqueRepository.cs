using System.Data.Entity;
using CMDataModel.Repository.Base;
using CMDataModel.Repository.Interfaces;

namespace CMDataModel.Repository
{
    public class EstoqueRepository : Repository<Estoque, CMDataEntities>, IEstoqueRepository
    {
        public EstoqueRepository(DbContext context) : base(context)
        {
        }
    }
}
