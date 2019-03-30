using System.Collections.Generic;
using CM.Core;
using CM.DataAccess;
using CM.Domain.BLL.Base;

namespace CM.Domain.BLL
{
    public class FornecedorBLL : BaseBLL<FornecedorDTO>
    {
        public override FornecedorDTO Get(object id)
        {
            return Get<Fornecedor>(id.ToString());
        }

        public override IEnumerable<FornecedorDTO> GetAll()
        {
            return GetAll<Fornecedor>();
        }

        public override void Add(FornecedorDTO dto)
        {
            Add<Fornecedor>(dto);
        }

        public override void Update(FornecedorDTO dto)
        {
            Update<Fornecedor>(dto);
        }

        public override void Remove(object id)
        {
            Remove<Fornecedor>(id.ToString());
        }
    }
}
