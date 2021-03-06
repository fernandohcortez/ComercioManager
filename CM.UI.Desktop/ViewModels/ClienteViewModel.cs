﻿using Caliburn.Micro;
using CM.UI.Desktop.ViewModels.Base;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models;
using CM.UI.Model.Validators;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ClienteViewModel : ViewModelBase<ClienteListaViewModel,ClienteEdicaoViewModel, ClienteModel, ClienteValidator>
    {
        #region Construtores

        public static ClienteViewModel Create()
        {
            return IoC.Get<ClienteViewModel>();
        }

        public ClienteViewModel(IApiHelper apiHelper) : base(apiHelper)
        {
            
        }

        #endregion
    }
}
