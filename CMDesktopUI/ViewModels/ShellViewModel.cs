using Caliburn.Micro;
using CMDesktopUI.Helpers;
using CMDesktopUI.Models;
using System.Windows;
using System.Windows.Input;

namespace CMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly LoginViewModel _loginVm;
        private readonly ProdutoViewModel _produtoVm;
        private readonly IApiHelper _apiHelper;
        private readonly UsuarioAutenticado _usuarioAutenticado;

        public ShellViewModel(LoginViewModel loginVM, IApiHelper apiHelper, UsuarioAutenticado usuarioAutenticado)
        {
            _apiHelper = apiHelper;

            _loginVm = loginVM;

            _usuarioAutenticado = usuarioAutenticado;

            ActivateItem(loginVM);
        }

        public RoutedEvent ProdutoScreen(object sender, MouseButtonEventArgs e)
        {
            //_produtoVm = produtoVm;

            ActivateItem(new ProdutoViewModel(_apiHelper));

            return e.RoutedEvent;
        }



        public void Sair()
        {
            ActivateItem(new ProdutoViewModel(_apiHelper));
            //Application.Current.Shutdown();
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

        //public void AbrirMenu()
        //{
        //    ButtonOpenMenu.Visibility = Visibility.Collapsed;
        //    ButtonCloseMenu.Visibility = Visibility.Visible;
        //}

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
