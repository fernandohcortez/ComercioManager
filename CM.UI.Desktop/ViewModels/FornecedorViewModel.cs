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
    public class FornecedorViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public FornecedorViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
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
