using Caliburn.Micro;
using CMDesktopUI.Helpers;
using PropertyChanged;
using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows;

namespace CMDesktopUI.ViewModels
{
    [DataContract]
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : Conductor<object>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IApiHelper _apiHelper;

        public LoginViewModel(IEventAggregator eventAggregator, IApiHelper apiHelper)
        {
            _eventAggregator = eventAggregator;
            _apiHelper = apiHelper;
        }

        [DataMember]
        public string Usuario { get; set; } = "fernandohcortez@gmail.com";

        private string _senha = "Growth@2018";
        [DataMember]
        public string Senha
        {
            get => _senha;
            set
            {
                _senha = value;
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool IsErrorVisible => MensagemErro?.Length > 0;

        private string _mensagemErro;
        [DataMember]
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

                await _apiHelper.Autenticar(Usuario, Senha);

                _eventAggregator.PublishOnUIThread("LoginOk");

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