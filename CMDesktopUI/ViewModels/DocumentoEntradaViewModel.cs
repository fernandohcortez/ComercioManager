using Caliburn.Micro;
using CMDesktopUI.Helpers;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using PropertyChanged;

namespace CMDesktopUI.ViewModels
{
    [DataContract]
    [AddINotifyPropertyChangedInterface]
    public class DocumentoEntradaViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public DocumentoEntradaViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string SerieNF { get; set; }
        [DataMember]
        public string NumeroNF { get; set; }
        [DataMember]
        public DateTime Data { get; set; }
        [DataMember]
        public int FornecedorId { get; set; }
        [DataMember]
        public decimal ValorSubTotal { get; set; }
        [DataMember]
        public decimal ValorImposto { get; set; }
        [DataMember]
        public decimal ValorTotal { get; set; }
        [DataMember]
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
