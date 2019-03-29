using System.Data.Entity;
using CM.DataAccess.Repository.Interfaces;
using CMDataModel.Repository.Base;

namespace CM.DataAccess.Repository
{
    public class PedidoVendaItemRepository : Repository<PedidoVendaItem, CMDataEntities>, IPedidoVendaItemRepository
    {
        public PedidoVendaItemRepository(DbContext context) : base(context)
        {
        }
    }
}
