using System.Data.Entity;
using CMDataModel.Repository.Base;
using CMDataModel.Repository.Interfaces;

namespace CMDataModel.Repository
{
    public class PedidoVendaItemRepository : Repository<PedidoVendaItem, CMDataEntities>, IPedidoVendaItemRepository
    {
        public PedidoVendaItemRepository(DbContext context) : base(context)
        {
        }
    }
}
