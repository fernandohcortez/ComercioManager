using System.Data.Entity;
using CM.DataAccess.Repository.Base;
using CM.DataAccess.Repository.Interfaces;

namespace CM.DataAccess.Repository
{
    internal class ClienteRepository : Repository<Cliente, CMDataEntities>, IClienteRepository
    {
        public ClienteRepository(DbContext context) : base(context)
        {
        }
    }
}
