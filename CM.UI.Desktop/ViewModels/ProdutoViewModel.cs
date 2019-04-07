using Caliburn.Micro;
using CM.UI.Desktop.Components;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProdutoViewModel : Conductor<object>.Collection.OneActive
    {
        private readonly IApiHelper _apiHelper;

        private ProdutoListaViewModel _produtoListaViewModel;

        private ProdutoModel RegistroCorrente => _produtoListaViewModel?.RegistroSelecionado;

        private AcaoCrud _acaoCrud;

        public ObservableCollection<ProdutoModel> ListaRegistros { get; set; }
        public bool IsBotaoSalvarVisivel { get; set; }
        public bool IsBotoesModoListaVisivel { get; set; } = true;

        private ProdutoEdicaoViewModel _produtoEdicaoViewModel;

        public static ProdutoViewModel Create()
        {
            return IoC.Get<ProdutoViewModel>();
        }

        public ProdutoViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;

            MostrarLista();
        }

        private async void MostrarLista()
        {
            await CarregarRegistros();

            _produtoListaViewModel = ProdutoListaViewModel.Create(Visualizar);
            _produtoListaViewModel.ListaRegistros = ListaRegistros;

            ActivateItem(_produtoListaViewModel);
        }

        public void LinhaGridSelecionada()
        {
            AbrirTelaEdicao(AcaoCrud.Visualizar);
        }

        private void ControlarVisibilidadeBotoes()
        {
            IsBotoesModoListaVisivel = _acaoCrud == AcaoCrud.Nenhuma;
            IsBotaoSalvarVisivel = _acaoCrud == AcaoCrud.Incluir || _acaoCrud == AcaoCrud.Alterar;
        }

        public void AbrirTelaEdicao(AcaoCrud acaoCrud)
        {
            _acaoCrud = acaoCrud;

            ControlarVisibilidadeBotoes();

            var somenteLeitura = acaoCrud == AcaoCrud.Visualizar;

            var registro = acaoCrud == AcaoCrud.Incluir ? new ProdutoModel() : RegistroCorrente;

            _produtoEdicaoViewModel = ProdutoEdicaoViewModel.Create(somenteLeitura, registro);

            ActivateItem(_produtoEdicaoViewModel);

            //var conductor = Parent as IConductor;
            //conductor?.ActivateItem(ProdutoEdicaoViewModel.Create(acaoCrud, RegistroSelecionadoGrid));

            //return;

            //dynamic settings = new ExpandoObject();
            //settings.Width = 1024;
            //settings.Height = 768;
            //settings.SizeToContent = SizeToContent.Manual;
            //settings.WindowStyle = WindowStyle.None;
            //settings.AllowsTransparency = true;

            //var dialogResult = _windowManager.ShowDialog(ProdutoViewModel.Create(acaoCrud, RegistroSelecionadoGrid), null, settings);

            //if (dialogResult)
            //    CarregarGrid();
        }

        public void Incluir()
        {
            AbrirTelaEdicao(AcaoCrud.Incluir);
        }

        public void Alterar()
        {
            AbrirTelaEdicao(AcaoCrud.Alterar);
        }

        public void Visualizar()
        {
            AbrirTelaEdicao(AcaoCrud.Visualizar);
        }

        public async void Remover()
        {
            if (RegistroCorrente == null)
                return;

            if (Mensagem.Create().MostrarPergunta("Deseja remover o registro selecionado?") == MessageBoxResult.No)
                return;
            try
            {
                await _apiHelper.RemoverProduto(RegistroCorrente);

                ListaRegistros.Remove(RegistroCorrente);
            }
            catch (Exception e)
            {
                Mensagem.Create().MostrarErro($"Erro na remoção do registro.\r\n\r\n{e.Message}");
            }
        }

        public async void Atualizar()
        {
            await CarregarRegistros();
        }

        public async Task CarregarRegistros()
        {
            var result = await _apiHelper.ListarProdutos();

            ListaRegistros = result;
        }

        public async void Salvar()
        {
            try
            {
                switch (_acaoCrud)
                {
                    case AcaoCrud.Incluir:
                        await _apiHelper.IncluirProduto(RegistroCorrente);
                        break;
                    case AcaoCrud.Alterar:
                        await _apiHelper.AlterarProduto(RegistroCorrente);
                        break;
                }

                _acaoCrud = AcaoCrud.Nenhuma;

                Voltar();
            }
            catch (Exception e)
            {
                Mensagem.Create().MostrarErro($"Erro na inclusão do registro.\r\n\r\n{e.Message}");
            }
        }

        public void Voltar()
        {
            if (!(ActiveItem is ProdutoEdicaoViewModel produtoEdicaoViewModel))
                return;

            _acaoCrud = AcaoCrud.Nenhuma;

            ControlarVisibilidadeBotoes();

            produtoEdicaoViewModel.TryClose();
        }

        public void Fechar()
        {
            TryClose();
        }
    }
}
