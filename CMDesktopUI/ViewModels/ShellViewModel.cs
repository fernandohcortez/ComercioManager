using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly LoginViewModel _loginVm;

        public ShellViewModel(LoginViewModel loginVm)
        {
            _loginVm = loginVm;

            ActivateItem(_loginVm);
        }
    }
}
