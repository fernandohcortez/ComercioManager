using System.Data.Entity;
using CM.DataAccess.Repository.Base;
using CM.DataAccess.Repository.Interfaces;

namespace CM.DataAccess.Repository
{
    public class DocumentoEntradaItemRepository : Repository<DocumentoEntradaItem, CMDataEntities>, IDocumentoEntradaItemRepository
    {
        public DocumentoEntradaItemRepository(DbContext context) : base(context)
        {
        }
    }
}
