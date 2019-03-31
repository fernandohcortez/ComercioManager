using Caliburn.Micro;
using CM.Core;
using CMDesktopUI.Helpers;
using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using PropertyChanged;

namespace CMDesktopUI.ViewModels
{
    [DataContract]
    [AddINotifyPropertyChangedInterface]
    public class ProdutoViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public ProdutoViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public decimal PrecoVenda { get; set; }

        public async Task Salvar()
        {
            try
            {
                await _apiHelper.IncluirProduto(this);
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
