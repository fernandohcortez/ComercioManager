using System.Data.Entity;
using CM.DataAccess.Repository.Base;
using CM.DataAccess.Repository.Interfaces;

namespace CM.DataAccess.Repository
{
    public class PedidoVendaItemRepository : Repository<PedidoVendaItem, CMDataEntities>, IPedidoVendaItemRepository
    {
        public PedidoVendaItemRepository(DbContext context) : base(context)
        {
        }
    }
}
