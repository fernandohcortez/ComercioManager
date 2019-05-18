using CM.UI.Desktop.ViewModels.Base;
using CM.UI.Model.Models;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class UsuarioListaViewModel : ListaViewModelBase<UsuarioModel>
    {
        public string Filtro
        {
            set
            {
                ListaRegistros.Filter = m => ((UsuarioModel)m).Email.ToUpper().Contains(value.ToUpper())
                                             || ((UsuarioModel)m).PrimeiroNome.ToUpper().Contains(value.ToUpper())
                                             || ((UsuarioModel)m).UltimoNome.ToUpper().Contains(value.ToUpper());
            }
        }
    }
}
