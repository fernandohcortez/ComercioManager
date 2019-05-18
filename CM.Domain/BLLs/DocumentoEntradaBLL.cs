using System.Collections.Generic;
using System.Threading.Tasks;
using CM.Core;
using CM.DataAccess;
using CM.Domain.BLLs.Base;
using CM.Domain.Helpers;
using Helpers;

namespace CM.Domain.BLLs
{
    public class DocumentoEntradaBLL : BaseBLL<DocumentoEntradaDTO>
    {
        public override async Task<DocumentoEntradaDTO> GetAsync(object id)
        {
            return await GetAsync<DocumentoEntrada>(id.IsNullOrEmptyThenZero());
        }

        public override async Task<IEnumerable<DocumentoEntradaDTO>> GetAllAsync()
        {
            return await GetAllAsync<DocumentoEntrada>();
        }

        public override async Task<DocumentoEntradaDTO> AddAsync(DocumentoEntradaDTO dto)
        {
            return await AddAsync<Cliente>(dto);
        }

        public override async Task UpdateAsync(DocumentoEntradaDTO dto)
        {
            await UpdateAsync<DocumentoEntrada>(dto, true);
        }

        public override async Task RemoveAsync(object id)
        {
            await RemoveAsync<DocumentoEntrada>(id.IsNullOrEmptyThenZero(), true);
        }

        public async Task<DocumentoEntradaDTO> IncluirAsync(DocumentoEntradaDTO documentoEntradaDTO)
        {
            var documentoEntradaIncluso = await AddAsync(documentoEntradaDTO);

            var estoqueBll = new EstoqueBLL(ContextHelper);

            foreach (var item in documentoEntradaDTO.Itens)
            {
                await estoqueBll.MovimentarEstoqueAsync(TipoMovimentoEstoque.Entrada, item.ProdutoId, item.Quantidade, item.ValorUnitario);
            }

            await ContextHelper.CommitAsync();

            return documentoEntradaIncluso;
        }
    }
}
