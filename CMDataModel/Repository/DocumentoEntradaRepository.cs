using System.Data.Entity;
using CM.DataAccess.Repository.Interfaces;
using CMDataModel.Repository.Base;

namespace CM.DataAccess.Repository
{
    public class DocumentoEntradaRepository : Repository<DocumentoEntrada, CMDataEntities>, IDocumentoEntradaRepository
    {
        public DocumentoEntradaRepository(DbContext context) : base(context)
        {
        }
    }
}
