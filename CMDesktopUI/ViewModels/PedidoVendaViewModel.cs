using Caliburn.Micro;
using CMDesktopUI.Helpers;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CMDesktopUI.ViewModels
{
    public class PedidoVendaViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public PedidoVendaViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        private DateTime _data;
        public DateTime Data
        {
            get => _data;
            set
            {
                _data = value;
                NotifyOfPropertyChange(() => Data);
            }
        }

        private int _clienterId;
        public int ClienteId
        {
            get => _clienterId;
            set
            {
                _clienterId = value;
                NotifyOfPropertyChange(() => ClienteId);
            }
        }

        private decimal _valorSubTotal;
        public decimal ValorSubTotal
        {
            get => _valorSubTotal;
            set
            {
                _valorSubTotal = value;
                NotifyOfPropertyChange(() => ValorSubTotal);
            }
        }

        private decimal _valorImposto;
        public decimal ValorImposto
        {
            get => _valorImposto;
            set
            {
                _valorImposto = value;
                NotifyOfPropertyChange(() => ValorImposto);
            }
        }

        private decimal _valorTotal;
        public decimal ValorTotal
        {
            get => _valorTotal;
            set
            {
                _valorTotal = value;
                NotifyOfPropertyChange(() => ValorTotal);
            }
        }

        private string _usuarioIdCaixa;
        public string UsuarioIdCaixa
        {
            get => _usuarioIdCaixa;
            set
            {
                _usuarioIdCaixa = value;
                NotifyOfPropertyChange(() => UsuarioIdCaixa);
            }
        }

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
