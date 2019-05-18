using System.Collections.Generic;
using System.Threading.Tasks;
using CM.Core;
using CM.DataAccess;
using CM.Domain.BLLs.Base;
using CM.Domain.Helpers;
using Helpers;

namespace CM.Domain.BLLs
{
    public class PedidoVendaBLL : BaseBLL<PedidoVendaDTO>
    {
        public override async Task<PedidoVendaDTO> GetAsync(object id)
        {
            return await GetAsync<PedidoVenda>(id.IsNullOrEmptyThenZero());
        }

        public override async Task<IEnumerable<PedidoVendaDTO>> GetAllAsync()
        {
            return await GetAllAsync<PedidoVenda>();
        }

        public override async Task<PedidoVendaDTO> AddAsync(PedidoVendaDTO dto)
        {
            return await AddAsync<PedidoVenda>(dto);
        }

        public override async Task UpdateAsync(PedidoVendaDTO dto)
        {
            await UpdateAsync<PedidoVenda>(dto, true);
        }

        public override async Task RemoveAsync(object id)
        {
            await RemoveAsync<PedidoVenda>(id.IsNullOrEmptyThenZero(), true);
        }

        public async Task<PedidoVendaDTO> IncluirAsync(PedidoVendaDTO pedidoVendaDTO)
        {
            var pedidoVendaInclusoDTO = await AddAsync(pedidoVendaDTO);

            var estoqueBll = new EstoqueBLL(ContextHelper);

            foreach (var item in pedidoVendaDTO.Itens)
            {
                await estoqueBll.MovimentarEstoqueAsync(TipoMovimentoEstoque.Saida, item.ProdutoId, item.Quantidade, item.ValorUnitario);
            }

            await ContextHelper.CommitAsync();

            return pedidoVendaInclusoDTO;
        }
    }
}
