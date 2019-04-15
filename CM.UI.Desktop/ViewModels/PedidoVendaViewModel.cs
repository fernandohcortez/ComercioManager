using Caliburn.Micro;
using CM.UI.Model.Helpers;
using PropertyChanged;
using System;
using System.Threading.Tasks;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PedidoVendaViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public PedidoVendaViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int ClienteId { get; set; }
        public decimal ValorSubTotal { get; set; }
        public decimal ValorImposto { get; set; }
        public decimal ValorTotal { get; set; }
        public string UsuarioIdCaixa { get; set; }

        //public BindingList<PedidoVendaItem> Itens { get; set; }

        public async Task Incluir()
        {
            try
            {
               //await _apiHelper.IncluirPedidoVenda();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Fechar()
        {
            TryClose();
        }
    }
}
