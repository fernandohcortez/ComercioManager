using Caliburn.Micro;
using CM.UI.Desktop.Components;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Windows;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProdutoListaViewModel : Conductor<object>
    {
        private readonly IWindowManager _windowManager;
        private readonly IApiHelper _apiHelper;

        public ObservableCollection<ProdutoModel> Grid { get; set; }

        public ProdutoModel RegistroSelecionadoGrid { get; set; }

        public static ProdutoListaViewModel Create()
        {
            return IoC.Get<ProdutoListaViewModel>();
        }

        public ProdutoListaViewModel(IWindowManager windowManager, IApiHelper apiHelper)
        {
            _windowManager = windowManager;
            _apiHelper = apiHelper;

            CarregarGrid();
        }

        public async void CarregarGrid()
        {
            var listaProdutos = await _apiHelper.ListarProdutos();

            Grid = listaProdutos;
        }

        public void LinhaGridSelecionada()
        {
            AbrirTelaDetalhes(AcaoCrud.Visualizar);
        }

        public void AbrirTelaDetalhes(AcaoCrud acaoCrud)
        {
            dynamic settings = new ExpandoObject();
            settings.Width = 1024;
            settings.Height = 768;
            settings.SizeToContent = SizeToContent.Manual;
            settings.WindowStyle = WindowStyle.None;
            settings.AllowsTransparency = true;

            var dialogResult = _windowManager.ShowDialog(ProdutoViewModel.Create(acaoCrud, RegistroSelecionadoGrid), null, settings);

            if (dialogResult)
                CarregarGrid();
        }

        public void Incluir()
        {
            AbrirTelaDetalhes(AcaoCrud.Incluir);
        }

        public void Alterar()
        {
            AbrirTelaDetalhes(AcaoCrud.Alterar);
        }

        public void Visualizar()
        {
            AbrirTelaDetalhes(AcaoCrud.Visualizar);
        }

        public async void Remover()
        {
            if (RegistroSelecionadoGrid == null)
                return;

            if (Mensagem.Create().MostrarPergunta("Deseja remover o registro selecionado?") == MessageBoxResult.No)
                return;
            try
            {
                await _apiHelper.RemoverProduto(RegistroSelecionadoGrid);

                Grid.Remove(RegistroSelecionadoGrid);
            }
            catch (Exception e)
            {
                Mensagem.Create().MostrarErro($"Erro na remoção do registro.\r\n\r\n{e.Message}");
            }
        }

        public void Atualizar()
        {
            CarregarGrid();
        }

        public void Fechar()
        {
            TryClose();
        }
    }
}
