using Caliburn.Micro;
using CMDesktopUI.Helpers;

namespace CMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly Login2ViewModel _loginVm;
        private ProdutoViewModel _produtoVm;
        private readonly IApiHelper _apiHelper;

        public ShellViewModel(Login2ViewModel loginVM, IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;

            _loginVm = loginVM;

            ActivateItem(loginVM);
        }

        public void ProdutoScreen()
        {
            //_produtoVm = produtoVm;

            ActivateItem(new ProdutoViewModel(_apiHelper));
        }

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
