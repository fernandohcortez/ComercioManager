using System.Collections.Generic;
using CM.UI.Desktop.ViewModels.Base;
using CM.UI.Model.Models;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class FornecedorEdicaoViewModel : EdicaoViewModelBase<FornecedorModel>
    {
        public List<EstadoModel> ListaEstados => new ListaEstadoModel().Estados;
    }
}
