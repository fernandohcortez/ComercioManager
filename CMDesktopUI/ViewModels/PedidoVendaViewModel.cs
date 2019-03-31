using Caliburn.Micro;
using CMDesktopUI.Helpers;
using PropertyChanged;
using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CMDesktopUI.ViewModels
{
    [DataContract]
    [AddINotifyPropertyChangedInterface]
    public class PedidoVendaViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public PedidoVendaViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Data { get; set; }
        [DataMember]
        public int ClienteId { get; set; }
        [DataMember]
        public decimal ValorSubTotal { get; set; }
        [DataMember]
        public decimal ValorImposto { get; set; }
        [DataMember]
        public decimal ValorTotal { get; set; }
        [DataMember]
        public string UsuarioIdCaixa { get; set; }

        //public BindingList<PedidoVendaItem> Itens { get; set; }

        public async Task Incluir()
        {
            try
            {
                await _apiHelper.IncluirPedidoVenda();
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
