using CM.Core;
using CM.DataAccess;
using CM.Domain.BLLs.Base;
using CM.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Threading;
using Helpers;

namespace CM.Domain.BLLs
{
    public class ProdutoBLL : BaseBLL<ProdutoDTO>
    {
        public EstoqueBLL EstoqueBLL => new EstoqueBLL(ContextHelper);

        public override ProdutoDTO Get(object id)
        {
            return Get<Produto>(id.IsNullOrEmptyThenZero());
        }

        public override IEnumerable<ProdutoDTO> GetAll()
        {
            return GetAll<Produto>();
        }

        public override ProdutoDTO Add(ProdutoDTO dto)
        {
            try
            {
                var entity = Mapping.Mapper.Map<Produto>(dto);

                Add(entity);

                EstoqueBLL.IncluirEstoqueInicial(entity.Id);

                ContextHelper.Commit();

                dto = Mapping.Mapper.Map<ProdutoDTO>(entity);

                return dto;
            }
            catch (Exception)
            {
                ContextHelper.Rollback();

                throw;
            }
        }

        public override void Update(ProdutoDTO dto)
        {
            Update<Produto>(dto, true);
        }

        public override void Remove(object id)
        {

            var produtoId = id.IsNullOrEmptyThenZero();

            try
            {
                var produto = ContextHelper.DbSet.Get<Produto>(produtoId);

                EstoqueBLL.RemoverEstoqueProduto(produto);

                Remove<Produto>(produtoId);

                ContextHelper.Commit();
            }
            catch (Exception)
            {
                ContextHelper.Rollback();

                throw;
            }
        }
    }
}
