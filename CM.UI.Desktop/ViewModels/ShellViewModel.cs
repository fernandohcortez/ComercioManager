using Caliburn.Micro;
using CM.UI.Desktop.Components;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models.Interface;
using Helpers;
using PropertyChanged;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows;
using CM.UI.Model.Models;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ShellViewModel : Conductor<object>, IHandle<string>
    {
        #region Campos e Propriedades

        private readonly UsuarioModel _usuarioModel;
        private readonly IApiHelper _apiHelper;
        private readonly LoginViewModel _loginVm;

        public bool IniciarAnimacaoAbrirMenu { get; set; }
        public bool IsBotaoAbrirMenuVisible { get; set; }
        public bool IsBotaoFecharMenuVisible { get; set; }
        public string NomeUsuario { get; set; }
        public byte[] FotoUsuario { get; set; }
        public bool UsuarioAdministrador { get; set; }

        #endregion

        #region Construtor

        public ShellViewModel(
            IApiHelper apiHelper,
            IEventAggregator eventAggregator,
            IUsuarioModel usuarioModel,
            LoginViewModel loginVm)
        {
            eventAggregator.Subscribe(this);

            _apiHelper = apiHelper;
            _loginVm = loginVm;
            _usuarioModel = usuarioModel as UsuarioModel;

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

        public void AbrirContasUsuarios()
        {
            ActivateItem(UsuarioViewModel.Create());
        }

        #endregion

        #region Eventos

        public void Handle(string message)
        {
            if (message == "LoginOk")
            {
                if (IniciarAnimacaoAbrirMenu)
                    InciarAnimacaoFecharMenu();

                UsuarioAdministrador = _usuarioModel.Administrador;

                NomeUsuario = _usuarioModel.PrimeiroNome;

                //var caminhoAssets = @"C:\ProjetosVS\ComercioManager\CM.UI.Desktop\Assets\";

                //var caminhoFoto = Path.Combine(caminhoAssets, "FotoUsuario.jpg");

                //var foto = Image.FromFile(caminhoFoto);

                //_usuarioModel.Foto = ImageHelper.ImageToByteArray(foto);

                //_apiHelper.Alterar(_usuarioModel, $"{_usuarioModel.Id}/");

                FotoUsuario = _usuarioModel.Foto;

                InciarAnimacaoAbrirMenu();
            }
        }



        public void InciarAnimacaoAbrirMenu()
        {
            IniciarAnimacaoAbrirMenu = true;
            IsBotaoFecharMenuVisible = true;
        }

        public void InciarAnimacaoFecharMenu()
        {
            IniciarAnimacaoAbrirMenu = false;
            IsBotaoFecharMenuVisible = false;
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
