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
        private readonly IApiHelper _apiHelper;
        private readonly IUsuarioLogadoModel _usuarioLogadoModel;

        private readonly LoginViewModel _loginVm;

        public bool IniciarAnimacaoAbrirMenu { get; set; }
        public bool IsBotaoAbrirMenuVisible { get; set; }
        public bool IsBotaoFecharMenuVisible { get; set; }
        public string NomeUsuario { get; set; }

        public ShellViewModel(
            IEventAggregator eventAggregator,
            IApiHelper apiHelper,
            IUsuarioLogadoModel usuarioLogadoModel,
            LoginViewModel loginVm)
        {
            eventAggregator.Subscribe(this);

            _apiHelper = apiHelper;
            _loginVm = loginVm;
            _usuarioLogadoModel = usuarioLogadoModel;

            ActivateItem(_loginVm);
        }

        public void MenuClienteSelecionado()
        {

        }

        public void MenuFornecedorSelecionado()
        {

        }

        public void MenuProdutoSelecionado()
        {
            ActivateItem(ProdutoListaViewModel.Create());
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

        public void Procurar()
        {

        }

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
    }
}
