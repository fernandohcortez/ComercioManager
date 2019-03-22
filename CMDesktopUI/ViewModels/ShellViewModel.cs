using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CMDesktopUI.Helpers;

namespace CMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly LoginViewModel _loginVm;
        private ProdutoViewModel _produtoVm;

        public ShellViewModel(LoginViewModel loginVm)
        {
            _loginVm = loginVm;

            ActivateItem(_loginVm);
        }

        public void ProdutoScreen(IApiHelper apiHelper)
        {
            //_produtoVm = produtoVm;

            ActivateItem(new ProdutoViewModel(apiHelper));
        }

    }
}
