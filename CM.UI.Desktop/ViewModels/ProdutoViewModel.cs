using Caliburn.Micro;
using CM.UI.Desktop.Components;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models;
using PropertyChanged;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProdutoViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;
        private AcaoCrud _acaoCrud;
        public bool IsBotaoSalvarVisivel { get; set; }
        public bool IsViewSomenteLeitura { get; set; }

        public ProdutoModel ProdutoModel { get; set; }

        public static ProdutoViewModel Create(AcaoCrud acaoCrud, ProdutoModel produtoModel = null)
        {
            var instancia = IoC.Get<ProdutoViewModel>();

            instancia._acaoCrud = acaoCrud;
            instancia.ProdutoModel = acaoCrud == AcaoCrud.Incluir ? new ProdutoModel() : produtoModel;
            instancia.IsBotaoSalvarVisivel = acaoCrud == AcaoCrud.Incluir || acaoCrud == AcaoCrud.Alterar;
            instancia.IsViewSomenteLeitura = acaoCrud == AcaoCrud.Visualizar || acaoCrud == AcaoCrud.Remover;

            return instancia;
        }

        public ProdutoViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task Salvar()
        {
            try
            {
                switch (_acaoCrud)
                {
                    case AcaoCrud.Incluir:
                        await _apiHelper.IncluirProduto(ProdutoModel);
                        break;
                    case AcaoCrud.Alterar:
                        await _apiHelper.AlterarProduto(ProdutoModel);
                        break;
                }

                TryClose(true);
            }
            catch (Exception e)
            {
                Mensagem.Create().MostrarErro($"Erro na inclusão do registro.\r\n\r\n{e.Message}");
            }
        }

        public void Fechar()
        {
            if (_acaoCrud == AcaoCrud.Incluir || _acaoCrud == AcaoCrud.Alterar)
            {
                if (Mensagem.Create().MostrarPergunta("O registro ainda não foi salvo.\r\nDeseja sair mesmo assim?") == MessageBoxResult.No)
                    return;
            }

            TryClose(false);
        }
    }
}
