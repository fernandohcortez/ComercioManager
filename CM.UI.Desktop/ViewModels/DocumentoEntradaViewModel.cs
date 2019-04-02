using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Caliburn.Micro;
using CM.UI.Desktop.Helpers;
using CM.UI.Model.Helpers;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DocumentoEntradaViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public DocumentoEntradaViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public int Id { get; set; }
        public string SerieNF { get; set; }
        public string NumeroNF { get; set; }
        public DateTime Data { get; set; }
        public int FornecedorId { get; set; }
        public decimal ValorSubTotal { get; set; }
        public decimal ValorImposto { get; set; }
        public decimal ValorTotal { get; set; }
        public string Status { get; set; }

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
