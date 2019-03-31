using Caliburn.Micro;
using CMDesktopUI.Helpers;
using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using PropertyChanged;

namespace CMDesktopUI.ViewModels
{
    [DataContract]
    [AddINotifyPropertyChangedInterface]
    public class FornecedorViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public FornecedorViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string RazaoSocial { get; set; }
        [DataMember]
        public string NomeFantasia { get; set; }
        [DataMember]
        public string Cnpj { get; set; }
        [DataMember]
        public string InscricaoEstadual { get; set; }
        [DataMember]
        public string Fone1 { get; set; }
        [DataMember]
        public string Fone2 { get; set; }
        [DataMember]
        public string Endereco { get; set; }
        [DataMember]
        public string Complemento { get; set; }
        [DataMember]
        public string Bairro { get; set; }
        [DataMember]
        public string Cidade { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Email { get; set; }

        public async Task Incluir()
        {
            try
            {
                await _apiHelper.IncluirFornecedor();
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
