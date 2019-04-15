using System.Collections.Generic;
using CM.Core;
using CM.DataAccess;
using CM.Domain.BLLs.Base;
using CM.Domain.Helpers;

namespace CM.Domain.BLLs
{
    public class FornecedorBLL : BaseBLL<FornecedorDTO>
    {
        public override FornecedorDTO Get(object id)
        {
            return Get<Fornecedor>(id.IsNullOrEmptyThenZero());
        }

        public override IEnumerable<FornecedorDTO> GetAll()
        {
            return GetAll<Fornecedor>();
        }

        public override FornecedorDTO Add(FornecedorDTO dto)
        {
            return Add<Fornecedor>(dto, true);
        }

        public override void Update(FornecedorDTO dto)
        {
            Update<Fornecedor>(dto, true);
        }

        public override void Remove(object id)
        {
            Remove<Fornecedor>(id.IsNullOrEmptyThenZero(), true);
        }
    }
}
