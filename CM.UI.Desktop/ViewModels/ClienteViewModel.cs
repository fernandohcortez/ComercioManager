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
    public class ClienteViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public ClienteViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public DateTime DataNascimento { get; set; }
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
                await _apiHelper.IncluirCliente();
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
