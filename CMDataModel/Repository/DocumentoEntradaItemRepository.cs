using System.Data.Entity;
using CMDataModel.Repository.Base;
using CMDataModel.Repository.Interfaces;

namespace CMDataModel.Repository
{
    public class DocumentoEntradaItemRepository : Repository<DocumentoEntradaItem, CMDataEntities>, IDocumentoEntradaItemRepository
    {
        public DocumentoEntradaItemRepository(DbContext context) : base(context)
        {
        }
    }
}
