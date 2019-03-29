using System.Data.Entity;
using CM.DataAccess.Repository.Interfaces;
using CMDataModel.Repository.Base;

namespace CM.DataAccess.Repository
{
    public class DocumentoEntradaItemRepository : Repository<DocumentoEntradaItem, CMDataEntities>, IDocumentoEntradaItemRepository
    {
        public DocumentoEntradaItemRepository(DbContext context) : base(context)
        {
        }
    }
}
