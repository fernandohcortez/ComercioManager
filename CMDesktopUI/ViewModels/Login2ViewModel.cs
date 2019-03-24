using Caliburn.Micro;
using CMDesktopUI.Helpers;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace CMDesktopUI.ViewModels
{
    public class Login2ViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public Login2ViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        private string _usuario;
        public string Usuario
        {
            get => _usuario;
            set
            {
                _usuario = value;
                NotifyOfPropertyChange(() => Usuario);
            }
        }

        private string _senha;
        public string Senha
        {
            get => _senha;
            set
            {
                _senha = value;
                NotifyOfPropertyChange(() => Senha);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool IsErrorVisible => MensagemErro?.Length > 0;

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

        public async Task LogIn()
        {
            try
            {
                MensagemErro = string.Empty;

                var resultado = await _apiHelper.Autenticar(Usuario, Senha);

                TryClose();
            }
            catch (Exception e)
            {
                MensagemErro = e.Message;
            }
        }

        public void Sair()
        {
            Application.Current.Shutdown();
        }

        public void EsqueceuSenha()
        {
            MensagemErro = "Função ainda não disponível.";
        }
    }
}