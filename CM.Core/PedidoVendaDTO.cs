using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Core.Base;

namespace CM.Core
{
    public class PedidoVendaDTO : IBaseDTO
    {
        public int Id { get; set; }

        public List<PedidoVendaItemDTO> Itens { get; set; }
    }
}
