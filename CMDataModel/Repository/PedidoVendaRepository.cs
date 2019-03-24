using System.Data.Entity;
using CMDataModel.Repository.Base;
using CMDataModel.Repository.Interfaces;

namespace CMDataModel.Repository
{
    public class PedidoVendaRepository : Repository<PedidoVenda, CMDataEntities>, IPedidoVendaRepository
    {
        public PedidoVendaRepository(DbContext context) : base(context)
        {
        }
    }
}
