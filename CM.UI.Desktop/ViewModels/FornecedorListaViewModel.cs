using CM.UI.Desktop.ViewModels.Base;
using CM.UI.Model.Models;
using Helpers;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class FornecedorListaViewModel : ListaViewModelBase<FornecedorModel>
    {
        public string FiltroNome
        {
            set { ListaRegistros.Filter = m => ((FornecedorModel)m).RazaoSocial.ToUpper().Contains(value.ToUpper()); }
        }

        public string FiltroCnpj
        {
            set { ListaRegistros.Filter = m => ((FornecedorModel)m).Cnpj.IsNullThenEmpty().Contains(value); }
        }
    }
}
