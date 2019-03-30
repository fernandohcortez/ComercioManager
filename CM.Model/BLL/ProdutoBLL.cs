using CM.Core;
using CM.DataAccess;
using CM.Domain.BLL.Base;
using System.Collections.Generic;

namespace CM.Domain.BLL
{
    public class ProdutoBLL : BaseBLL<ProdutoDTO>
    {
        public override ProdutoDTO Get(object id)
        {
            return Get<Produto>(id.ToString());
        }

        public override IEnumerable<ProdutoDTO> GetAll()
        {
            return GetAll<Produto>();
        }

        public override void Add(ProdutoDTO dto)
        {
            Add<Produto>(dto);

            var estoqueBll = new EstoqueBLL(ContextHelper);
            estoqueBll.IncluirEstoqueInicial(dto.Id);

            ContextHelper.Commit();
        }

        public override void Update(ProdutoDTO dto)
        {
            Update<Produto>(dto);
        }

        public override void Remove(object id)
        {
            Remove<Produto>(id.ToString());
        }
    }
}
