using System.Data.Entity;
using CM.DataAccess.Repository.Base;
using CM.DataAccess.Repository.Interfaces;

namespace CM.DataAccess.Repository
{
    public class PedidoVendaRepository : Repository<PedidoVenda, CMDataEntities>, IPedidoVendaRepository
    {
        public PedidoVendaRepository(DbContext context) : base(context)
        {
        }
    }
}
