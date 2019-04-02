using Caliburn.Micro;
using CM.UI.Model.Helpers;
using PropertyChanged;
using System;
using System.Threading.Tasks;
using CM.UI.Model.Models;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProdutoViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public ProdutoViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVenda { get; set; }

        public async Task Salvar()
        {
            try
            {
                var produtoModel = Mapping.Mapping.Mapper.Map<ProdutoModel>(this);

                await _apiHelper.IncluirProduto(produtoModel);
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
