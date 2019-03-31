using Caliburn.Micro;
using CMDesktopUI.Helpers;
using CMDesktopUI.Models;
using System.Windows;
using System.Windows.Controls;

namespace CMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<string>
    {
        private readonly LoginViewModel _loginVm;
        private readonly IApiHelper _apiHelper;
        private readonly UsuarioAutenticado _usuarioAutenticado;
        public bool IniciarAnimacaoAbrirMenu { get; set; }
        
        esconder// botao menu abrir até que o usuario logue.

        public ShellViewModel(IEventAggregator eventAggregator, LoginViewModel loginVm, IApiHelper apiHelper,
            UsuarioAutenticado usuarioAutenticado)
        {
            eventAggregator.Subscribe(this);

            _apiHelper = apiHelper;
            _loginVm = loginVm;
            _usuarioAutenticado = usuarioAutenticado;

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
            if (message == "LoginOk")
                InciarAnimacaoAbrirMenu();
        }

        public void InciarAnimacaoAbrirMenu()
        {
            IniciarAnimacaoAbrirMenu = true;
        }

        public void FecharMenu()
        {

        }

        //public void FecharMenu()
        //{
        //    ButtonOpenMenu.Visibility = Visibility.Collapsed;
        //    ButtonCloseMenu.Visibility = Visibility.Visible;
        //}

        //private Func<ProdutoViewModel> _vmFactory;

        //public ShellViewModel(Func<ProdutoViewModel> vmFactory)
        //{
        //    _vmFactory = vmFactory;
        //}

        //public void ProdutoScreen()
        //{
        //    var newVM = _vmFactory();
        //    ActivateItem(newVM);
        //}

    }
}
