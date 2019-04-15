using Caliburn.Micro;
using CM.UI.Desktop.Components;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models.Interface;
using PropertyChanged;
using System.Windows;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ShellViewModel : Conductor<object>, IHandle<string>
    {
        #region Campos e Propriedades

        private readonly IUsuarioLogadoModel _usuarioLogadoModel;
        private readonly LoginViewModel _loginVm;

        public bool IniciarAnimacaoAbrirMenu { get; set; }
        public bool IsBotaoAbrirMenuVisible { get; set; }
        public bool IsBotaoFecharMenuVisible { get; set; }
        public string NomeUsuario { get; set; }

        #endregion

        #region Construtor

        public ShellViewModel(
            IEventAggregator eventAggregator,
            IUsuarioLogadoModel usuarioLogadoModel,
            LoginViewModel loginVm)
        {
            eventAggregator.Subscribe(this);

            _loginVm = loginVm;
            _usuarioLogadoModel = usuarioLogadoModel;

            ActivateItem(_loginVm);
        }

        #endregion

        #region Menus

        public void MenuClienteSelecionado()
        {
            ActivateItem(ClienteViewModel.Create());
        }

        public void MenuFornecedorSelecionado()
        {
            ActivateItem(FornecedorViewModel.Create());
        }

        public void MenuProdutoSelecionado()
        {
            ActivateItem(ProdutoViewModel.Create());
        }

        public void MenuDocumentoEntradaSelecionado()
        {

        }

        public void MenuPedidoVendaSelecionado()
        {

        }

        public void MenuEstoqueSelecionado()
        {

        }

        #endregion

        #region Botões

        public void Sair()
        {
            if (Mensagem.Create().MostrarPergunta("Deseja encerrar o sistema?") == MessageBoxResult.No)
                return;

            Application.Current.Shutdown();
        }

        public void Restaurar()
        {
            if (Application.Current.MainWindow == null)
                return;

            Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState == WindowState.Normal
                ? WindowState.Maximized
                : WindowState.Normal;
        }

        public void Minimizar()
        {
            if (Application.Current.MainWindow == null)
                return;

            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        public void TrocarUsuario()
        {
            ActivateItem(_loginVm);
        }

        #endregion

        #region Eventos

        public void Handle(string message)
        {
            if (message != "LoginOk")
                return;

            NomeUsuario = _usuarioLogadoModel.PrimeiroNome;

            InciarAnimacaoAbrirMenu();
        }

        public void InciarAnimacaoAbrirMenu()
        {
            IniciarAnimacaoAbrirMenu = true;
            IsBotaoFecharMenuVisible = true;
        }

        public void AbrirMenu()
        {
            IsBotaoAbrirMenuVisible = false;
            IsBotaoFecharMenuVisible = true;
        }

        public void FecharMenu()
        {
            IsBotaoAbrirMenuVisible = true;
            IsBotaoFecharMenuVisible = false;
        }

        #endregion
    }
}
