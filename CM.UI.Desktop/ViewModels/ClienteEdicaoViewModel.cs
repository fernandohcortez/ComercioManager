using System;
using System.Collections.Generic;
using CM.UI.Desktop.ViewModels.Base;
using CM.UI.Model.Models;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ClienteEdicaoViewModel : EdicaoViewModelBase<ClienteModel>
    {
        #region Campos e Propriedades

        public List<EstadoModel> ListaEstados => new ListaEstadoModel().Estados;

        #endregion
    }
}
