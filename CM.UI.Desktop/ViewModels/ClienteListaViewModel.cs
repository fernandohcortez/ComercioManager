using CM.UI.Desktop.ViewModels.Base;
using CM.UI.Model.Models;
using Helpers;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ClienteListaViewModel : ListaViewModelBase<ClienteModel>
    {
        public string FiltroNome
        {
            set { ListaRegistros.Filter = m => ((ClienteModel)m).Nome.Contains(value); }
        }

        public string FiltroCpf
        {
            set { ListaRegistros.Filter = m => ((ClienteModel)m).Cpf.IsNullThenEmpty().Contains(value); }
        }
    }
}
