using Caliburn.Micro;
using CMDesktopUI.Helpers;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CMDesktopUI.ViewModels
{
    public class DocumentoEntradaViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public DocumentoEntradaViewModel(IApiHelper apiHelper)
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

        private string _serieNF;
        public string SerieNF
        {
            get => _serieNF;
            set
            {
                _serieNF = value;
                NotifyOfPropertyChange(() => SerieNF);
            }
        }

        private string _numeroNF;
        public string NumeroNF
        {
            get => _numeroNF;
            set
            {
                _numeroNF = value;
                NotifyOfPropertyChange(() => NumeroNF);
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

        private int _fornecedorId;
        public int FornecedorId
        {
            get => _fornecedorId;
            set
            {
                _fornecedorId = value;
                NotifyOfPropertyChange(() => FornecedorId);
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

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                NotifyOfPropertyChange(() => Status);
            }
        }

        //public BindingList<DocumentoEntradaItem> Itens { get; set; }

        public async Task Incluir()
        {
            try
            {
                await _apiHelper.IncluirDocumentoEntrada();
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
