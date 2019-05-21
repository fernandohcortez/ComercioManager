using Caliburn.Micro;
using CM.UI.Desktop.Components;
using CM.UI.Desktop.Properties;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models.Interface;
using Helpers;
using PropertyChanged;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ChangePasswordViewModel : Screen
    {
        #region Factory

        public static ChangePasswordViewModel Create(ChangePasswordViewType changePasswordViewType, string usernameResetPassword, string verificationCodeResetPassword)
        {
            var instance = IoC.Get<ChangePasswordViewModel>();

            instance.ChangePasswordViewType = changePasswordViewType;
            instance._usernameResetPassword = usernameResetPassword;
            instance._verificationCodeResetPassword = verificationCodeResetPassword;

            return instance;
        }

        #endregion

        #region Fields and Properties

        private readonly IApiHelper _apiHelper;
        private readonly IEventAggregator _eventAggregator;
        private readonly IUsuarioModel _usuarioModel;
        private string _usernameResetPassword;
        private string _verificationCodeResetPassword;

        private ChangePasswordViewType _changePasswordViewType = ChangePasswordViewType.Manual;
        private ChangePasswordViewType ChangePasswordViewType
        {
            get => _changePasswordViewType;
            set
            {
                _changePasswordViewType = value;

                SenhaAtual = value == ChangePasswordViewType.NewUserForceNewPassword ? Settings.Default.DefaultPassword.Unprotect() : string.Empty;
            }
        }

        public bool CurrentPasswordNeeded => ChangePasswordViewType == ChangePasswordViewType.Manual;
        
        public bool IsWaiting { get; set; }

        private string _senhaAtual;
        public string SenhaAtual
        {
            get => _senhaAtual;
            set
            {
                _senhaAtual = value;
                NotifyOfPropertyChange(() => CanAlterar);
            }
        }

        private string _novaSenha;
        public string NovaSenha
        {
            get => _novaSenha;
            set
            {
                _novaSenha = value;
                NotifyOfPropertyChange(() => CanAlterar);
            }
        }

        private string _confirmarSenha;
        public string ConfirmarSenha
        {
            get => _confirmarSenha;
            set
            {
                _confirmarSenha = value;
                NotifyOfPropertyChange(() => CanAlterar);
            }
        }

        public bool CanAlterar => (NovaSenha.IsNullThenEmpty().Length > 0 && ConfirmarSenha?.IsNullThenEmpty().Length > 0 && SenhaAtual.IsNullThenEmpty().Length > 0 && CurrentPasswordNeeded)
                                  || (NovaSenha.IsNullThenEmpty().Length > 0 && ConfirmarSenha?.IsNullThenEmpty().Length > 0 && !CurrentPasswordNeeded);


        #endregion

        #region Constructors and Activators

        public ChangePasswordViewModel(IApiHelper apiHelper, IEventAggregator eventAggregator, IUsuarioModel usuarioModel)
        {
            _apiHelper = apiHelper;
            _eventAggregator = eventAggregator;
            _usuarioModel = usuarioModel;

            SetEvents();
        }

        private void SetEvents()
        {
            Activated += ChangePasswordViewModel_Activated;
        }

        private void ChangePasswordViewModel_Activated(object sender, ActivationEventArgs e)
        {
            ClearInputData();
        }

        private void ClearInputData()
        {
            SenhaAtual = null;
            NovaSenha = null;
            ConfirmarSenha = null;
        }

        #endregion

        #region Buttons

        public async Task Alterar()
        {
            if (!Validate())
                return;

            try
            {
                IsWaiting = true;

                if (string.IsNullOrEmpty(_verificationCodeResetPassword))
                    await _apiHelper.ChangePassword(SenhaAtual, NovaSenha, ConfirmarSenha);
                else
                    await _apiHelper.ResetPassword(_usernameResetPassword, _verificationCodeResetPassword, NovaSenha);

                SaveLastPasswordLoggedIn();

                Mensagem.Create().MostrarInformacao("Senha alterada com sucesso!");

                PublishEventChangedPasswordOk();

                TryClose();
            }
            catch (Exception e)
            {
                Mensagem.Create().MostrarAlerta(e.Message);
            }
            finally
            {
                IsWaiting = false;
            }
        }

        private bool Validate()
        {
            if (!NovaSenha.Equals(ConfirmarSenha))
            {
                Mensagem.Create().MostrarAlerta("A confirmação da senha não confere com a nova senha.");
                return false;
            }

            if (NovaSenha.Equals(SenhaAtual))
            {
                Mensagem.Create().MostrarAlerta("A nova senha não pode ser igual a senha atual.");
                return false;
            }

            if (NovaSenha.Equals(Settings.Default.DefaultPassword.Unprotect()))
            {
                Mensagem.Create().MostrarAlerta("Esta senha não pode ser utilizada.");
                return false;
            }

            return true;
        }

        private void SaveLastPasswordLoggedIn()
        {
            Settings.Default.LastPasswordLoggedIn = Settings.Default.RememberPassword ? NovaSenha.Protect() : string.Empty;
            Settings.Default.Save();
        }

        private void PublishEventChangedPasswordOk()
        {
            _eventAggregator.PublishOnUIThread(ChangePasswordViewType);
        }

        public void Sair()
        {
            switch (ChangePasswordViewType)
            {
                case ChangePasswordViewType.NewUserForceNewPassword:
                    {
                        if (Mensagem.Create().MostrarPergunta("É obrigatório a troca da senha. Se continuar o sistema será encerrado.\r\n\r\nDeseja encerrar o sistema?") == MessageBoxResult.Yes)
                            Application.Current.Shutdown();

                        break;
                    }
                case ChangePasswordViewType.ForgottenPassword:
                    {
                        if (_usuarioModel.UsuarioLogado)
                        {
                            TryClose();
                        }
                        else
                        {
                            if (Mensagem.Create().MostrarPergunta("O sistema será encerrado se fechar esta tela sem concluir o processo de alteração de senha.\r\n\r\nDeseja continuar?") == MessageBoxResult.Yes)
                                Application.Current.Shutdown();
                        }

                        break;
                    }
                case ChangePasswordViewType.Manual:
                    {
                        TryClose();

                        break;
                    }
            }
        }

        #endregion
    }
}