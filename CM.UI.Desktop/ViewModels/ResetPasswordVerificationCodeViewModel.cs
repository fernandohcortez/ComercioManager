using Caliburn.Micro;
using CM.UI.Desktop.Components;
using CM.UI.Model.Models;
using CM.UI.Model.Models.Interface;
using Helpers;
using PropertyChanged;
using System;
using System.Windows;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ResetPasswordVerificationCodeViewModel : Screen
    {
        #region Factory

        public static ResetPasswordVerificationCodeViewModel Create(string username)
        {
            var instance = IoC.Get<ResetPasswordVerificationCodeViewModel>();

            instance._username = username;

            return instance;
        }

        #endregion

        #region Fields and Properties

        private readonly IEventAggregator _eventAggregator;
        private readonly IUsuarioModel _usuarioModel;

        private string _username;

        public bool IsWaiting { get; set; }
        public string Titulo => $"Redefinição de Senha de {_username}";

        private string _verificationCode;
        public string VerificationCode
        {
            get => _verificationCode;
            set
            {
                _verificationCode = value;
                NotifyOfPropertyChange(() => CanProsseguir);
            }
        }

        public bool CanProsseguir => VerificationCode.IsNullThenEmpty().Length > 0;

        #endregion

        #region Constructors and Activators

        public ResetPasswordVerificationCodeViewModel(IEventAggregator eventAggregator, IUsuarioModel usuarioModel)
        {
            _eventAggregator = eventAggregator;
            _usuarioModel = usuarioModel;

            SetEvents();
        }

        private void SetEvents()
        {
            Activated += ResetPasswordVerificationCodeViewModel_Activated;
        }

        private void ResetPasswordVerificationCodeViewModel_Activated(object sender, ActivationEventArgs e)
        {
            ClearInput();
        }

        private void ClearInput()
        {
            VerificationCode = string.Empty;
        }

        #endregion

        #region Buttons

        public void Prosseguir()
        {
            if (!Validate())
                return;

            try
            {
                IsWaiting = true;

                PublishEventResetPasswordOk();

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
            if (string.IsNullOrEmpty(VerificationCode))
            {
                Mensagem.Create().MostrarAlerta("Informe o código de recuperação recebido no seu email antes de prosseguir.");
                return false;
            }

            return true;
        }

        private void PublishEventResetPasswordOk()
        {
            var resetPasswordOkModel = new ResetPasswordModel
            {
                Username = _username,
                VerificationCode = VerificationCode
            };

            _eventAggregator.PublishOnUIThread(resetPasswordOkModel);
        }

        public void Sair()
        {
            if (_usuarioModel.UsuarioLogado)
            {
                TryClose();
            }
            else
            {
                if (Mensagem.Create().MostrarPergunta("O sistema será encerrado se fechar esta tela sem informar o código de recuperação.\r\n\r\nDeseja continuar?") == MessageBoxResult.Yes)
                    Application.Current.Shutdown();
            }
        }

        #endregion
    }
}