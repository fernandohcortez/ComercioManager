using System.Data.Entity;
using CM.DataAccess.Repository.Base;
using CM.DataAccess.Repository.Interfaces;

namespace CM.DataAccess.Repository
{
    public class DocumentoEntradaRepository : Repository<DocumentoEntrada, CMDataEntities>, IDocumentoEntradaRepository
    {
        public DocumentoEntradaRepository(DbContext context) : base(context)
        {
        }
    }
}
