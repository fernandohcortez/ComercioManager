using CM.Core;
using CM.DataAccess;
using CM.Domain.BLLs.Base;
using CM.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Helpers;

namespace CM.Domain.BLLs
{
    public class ProdutoBLL : BaseBLL<ProdutoDTO>
    {
        public EstoqueBLL EstoqueBLL => new EstoqueBLL(ContextHelper);

        public override async Task<ProdutoDTO> GetAsync(object id)
        {
            return await GetAsync<Produto>(id.IsNullOrEmptyThenZero());
        }

        public override async Task<IEnumerable<ProdutoDTO>> GetAllAsync()
        {
            return await GetAllAsync<Produto>();
        }

        public override async Task<ProdutoDTO> AddAsync(ProdutoDTO dto)
        {
            try
            {
                var entity = Mapping.Mapper.Map<Produto>(dto);

                Add(entity);

                await EstoqueBLL.IncluirEstoqueInicialAsync(entity.Id);

                await ContextHelper.CommitAsync();

                dto = Mapping.Mapper.Map<ProdutoDTO>(entity);

                return dto;
            }
            catch (Exception)
            {
                ContextHelper.Rollback();

                throw;
            }
        }

        public override async Task UpdateAsync(ProdutoDTO dto)
        {
            await UpdateAsync<Produto>(dto, true);
        }

        public override async Task RemoveAsync(object id)
        {
            var produtoId = id.IsNullOrEmptyThenZero();

            try
            {
                var produto = await ContextHelper.DbSet.GetAsync<Produto>(produtoId);

                await EstoqueBLL.RemoverEstoqueProdutoAsync(produto);

                Remove<Produto>(produtoId);

                await ContextHelper.CommitAsync();
            }
            catch (Exception)
            {
                ContextHelper.Rollback();

                throw;
            }
        }
    }
}
