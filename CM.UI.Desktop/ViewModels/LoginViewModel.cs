using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using CM.UI.Desktop.Helpers;
using CM.UI.Model.Helpers;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : Conductor<object>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IApiHelper _apiHelper;
        public bool IsWaiting { get; set; }

        public LoginViewModel(IEventAggregator eventAggregator, IApiHelper apiHelper)
        {
            _eventAggregator = eventAggregator;
            _apiHelper = apiHelper;
        }

        public string Usuario { get; set; } = "fernandohcortez@gmail.com";

        private string _senha = "Growth@2018";
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
                IsWaiting = true;

                MensagemErro = string.Empty;

                var result = await _apiHelper.Autenticar(Usuario, Senha);

                await _apiHelper.ObterInfoUsuarioLogado(result.Access_Token);

                _eventAggregator.PublishOnUIThread("LoginOk");

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