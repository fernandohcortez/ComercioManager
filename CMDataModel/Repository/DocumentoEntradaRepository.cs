using System.Data.Entity;
using CMDataModel.Repository.Base;
using CMDataModel.Repository.Interfaces;

namespace CMDataModel.Repository
{
    public class DocumentoEntradaRepository : Repository<DocumentoEntrada, CMDataEntities>, IDocumentoEntradaRepository
    {
        public DocumentoEntradaRepository(DbContext context) : base(context)
        {
        }
    }
}
