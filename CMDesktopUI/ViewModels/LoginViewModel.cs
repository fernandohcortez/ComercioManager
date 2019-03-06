using Caliburn.Micro;
using System;
using CMDesktopUI.Helpers;
using System.Threading.Tasks;

namespace CMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly IApiHelper _apiHelper;

        public LoginViewModel(IApiHelper apiHelper)
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

        public bool CanLogIn => Usuario?.Length > 0 && Senha?.Length > 0;

        public async Task LogIn()
        {
            try
            {
                var resultado = await _apiHelper.Autenticar(Usuario, Senha);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
