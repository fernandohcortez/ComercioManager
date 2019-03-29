using System.Data.Entity;
using CM.DataAccess.Repository.Interfaces;
using CMDataModel.Repository.Base;

namespace CM.DataAccess.Repository
{
    internal class ClienteRepository : Repository<Cliente, CMDataEntities>, IClienteRepository
    {
        public ClienteRepository(DbContext context) : base(context)
        {
        }
    }
}
