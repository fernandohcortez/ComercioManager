using Caliburn.Micro;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models.Interface;
using System.Windows;
using System.Windows.Controls;

namespace CM.UI.Desktop.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<string>
    {
        private readonly LoginViewModel _loginVm;
        private readonly IApiHelper _apiHelper;
        private readonly IUsuarioLogadoModel _usuarioLogadoModel;
        public bool IniciarAnimacaoAbrirMenu { get; set; }
        public bool IsBotaoAbrirMenuVisible { get; set; }
        public bool IsBotaoFecharMenuVisible { get; set; }
        public string NomeUsuario { get; set; }

        public ShellViewModel(IEventAggregator eventAggregator, LoginViewModel loginVm, IApiHelper apiHelper, IUsuarioLogadoModel usuarioLogadoModel)
        {
            eventAggregator.Subscribe(this);

            _apiHelper = apiHelper;
            _loginVm = loginVm;
            _usuarioLogadoModel = usuarioLogadoModel;

            ActivateItem(loginVm);
        }

        public void OnMenuSelecionado(ListViewItem listViewItem)
        {
            switch (listViewItem.Name)
            {
                case "LviProduto":
                    ActivateItem(new ProdutoViewModel(_apiHelper));
                    break;
                case "LviCliente":
                    break;
                case "LviFornecedor":
                    break;
                case "LviDocumentoEntrada":
                    break;
                case "LviPedidoVenda":
                    break;
            }
        }

        public void Sair()
        {
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
            ActivateItem(_loginVm);
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
