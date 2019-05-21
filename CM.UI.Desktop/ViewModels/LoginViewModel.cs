using Caliburn.Micro;
using CM.UI.Desktop.Components;
using CM.UI.Desktop.Properties;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models;
using CM.UI.Model.Models.Interface;
using Helpers;
using PropertyChanged;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : Screen
    {
        #region Fields and Properties

        private readonly IUsuarioModel _usuarioLogadoModel;
        private readonly IEventAggregator _eventAggregator;
        private readonly IApiHelper _apiHelper;

        public bool IsWaiting { get; set; }
        public bool LembrarSenha { get; set; }
        public bool IsErrorVisible => MensagemErro?.Length > 0;

        private string _usuario;
        public string Usuario
        {
            get => _usuario;
            set
            {
                _usuario = value;
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        private string _senha;
        public string Senha
        {
            get => _senha;
            set
            {
                _senha = value;
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        private string _mensagemErro;
        public string MensagemErro
        {
            get => _mensagemErro;
            set
            {
                _mensagemErro = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => MensagemErro);
            }
        }

        public bool CanLogIn => Usuario?.Length > 0 && Senha?.Length > 0;

        #endregion

        #region Constructors and Activators

        public LoginViewModel(IEventAggregator eventAggregator, IApiHelper apiHelper, IUsuarioModel usuarioLogadoModel)
        {
            _usuarioLogadoModel = usuarioLogadoModel;
            _eventAggregator = eventAggregator;
            _apiHelper = apiHelper;

            SetEvents();

            SetDefaultPassword();
        }

        private void SetEvents()
        {
            Activated += LoginViewModel_Activated;
        }

        private void SetDefaultPassword()
        {
            var defaultPassaword = "123mudar";

            if (!string.IsNullOrEmpty(Settings.Default.DefaultPassword) && Settings.Default.DefaultPassword.Unprotect().Equals(defaultPassaword))
                return;

            Settings.Default.DefaultPassword = defaultPassaword.Protect();
            Settings.Default.Save();
        }

        private void LoginViewModel_Activated(object sender, ActivationEventArgs e)
        {
            LoadLastUserLoggedIn();
        }

        private void LoadLastUserLoggedIn()
        {
            if (string.IsNullOrEmpty(Settings.Default.LastUserLoggedIn))
                return;

            Usuario = Settings.Default.LastUserLoggedIn;
            LembrarSenha = Settings.Default.RememberPassword;

            if (LembrarSenha)
                Senha = Settings.Default.LastPasswordLoggedIn.Unprotect();
        }

        #endregion

        #region Buttons

        public async Task LogIn()
        {
            try
            {
                IsWaiting = true;

                MensagemErro = string.Empty;

                await AutenticateUser();

                SaveLastLoginInfo();

                PublishEventLoginOk();

                TryClose();

            }
            catch (Exception e)
            {
                MensagemErro = e.Message;
            }
            finally
            {
                IsWaiting = false;
            }
        }

        private async Task AutenticateUser()
        {
            var result = await _apiHelper.Autenticar(Usuario, Senha);

            await _apiHelper.ObterInfoUsuarioLogado(result.Access_Token, Usuario);
        }

        private void SaveLastLoginInfo()
        {
            Settings.Default.LastUserLoggedIn = Usuario;
            Settings.Default.LastPasswordLoggedIn = LembrarSenha ? Senha.Protect() : string.Empty;
            Settings.Default.RememberPassword = LembrarSenha;
            Settings.Default.Save();
        }

        private void PublishEventLoginOk()
        {
            var forceChangePassword = Senha.Equals(Settings.Default.DefaultPassword.Unprotect());

            _eventAggregator.PublishOnUIThread(forceChangePassword ? "LoginOkWithChangePassword" : "LoginOk");
        }

        public async Task EsqueceuSenha()
        {
            if (string.IsNullOrEmpty(Usuario))
            {
                MensagemErro = "Informe o seu usuário.";
                return;
            }

            if (Mensagem.Create().MostrarPergunta($"Será encaminhado no email do usuário [{Usuario}] um código de recuperação para cadastro de uma nova senha.\r\n\r\nDeseja continuar?") == MessageBoxResult.No)
                return;

            try
            {
                IsWaiting = true;

                MensagemErro = string.Empty;

                await _apiHelper.PostFromUri(Usuario, "Account/SendEmailForgottenPassword");
            }
            catch (Exception e)
            {
                MensagemErro = e.Message;

                return;
            }
            finally
            {
                IsWaiting = false;
            }

            Mensagem.Create().MostrarInformacao("Verifique seu email e obtenha o código de recuperação de senha e informe na tela a seguir.");

            PublishEventResetPassword();

            TryClose();
        }

        private void PublishEventResetPassword()
        {
            var resetPasswordModel = new ResetPasswordModel
            {
                Username = Usuario
            };

            _eventAggregator.PublishOnUIThread(resetPasswordModel);
        }

        public void Sair()
        {
            var anyUserLoggedin = !string.IsNullOrEmpty(_usuarioLogadoModel.Token);

            if (anyUserLoggedin)
                TryClose();
            else
                Application.Current.Shutdown();
        }

        #endregion
    }
}