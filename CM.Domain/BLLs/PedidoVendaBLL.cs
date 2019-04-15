using System.Collections.Generic;
using CM.Core;
using CM.DataAccess;
using CM.Domain.BLLs.Base;
using CM.Domain.Helpers;

namespace CM.Domain.BLLs
{
    public class PedidoVendaBLL : BaseBLL<PedidoVendaDTO>
    {
        public override PedidoVendaDTO Get(object id)
        {
            return Get<PedidoVenda>(id.IsNullOrEmptyThenZero());
        }

        public override IEnumerable<PedidoVendaDTO> GetAll()
        {
            return GetAll<PedidoVenda>();
        }

        public override PedidoVendaDTO Add(PedidoVendaDTO dto)
        {
            return Add<PedidoVenda>(dto);
        }

        public override void Update(PedidoVendaDTO dto)
        {
            Update<PedidoVenda>(dto, true);
        }

        public override void Remove(object id)
        {
            Remove<PedidoVenda>(id.IsNullOrEmptyThenZero(), true);
        }

        public PedidoVendaDTO Incluir(PedidoVendaDTO pedidoVendaDTO)
        {
            var pedidoVendaInclusoDTO = Add(pedidoVendaDTO);

            var estoqueBll = new EstoqueBLL(ContextHelper);

            foreach (var item in pedidoVendaDTO.Itens)
            {
                estoqueBll.MovimentarEstoque(TipoMovimentoEstoque.Saida, item.ProdutoId, item.Quantidade, item.ValorUnitario);
            }

            ContextHelper.Commit();

            return pedidoVendaInclusoDTO;
        }
    }
}
