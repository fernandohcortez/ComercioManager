using Caliburn.Micro;
using CM.UI.Desktop.ViewModels.Base;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models;
using CM.UI.Model.Validators;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class FornecedorViewModel : ViewModelBase<FornecedorListaViewModel, FornecedorEdicaoViewModel, FornecedorModel, FornecedorValidator>
    {
        #region Construtores

        public static FornecedorViewModel Create()
        {
            return IoC.Get<FornecedorViewModel>();
        }

        public FornecedorViewModel(IApiHelper apiHelper) : base(apiHelper)
        {
            
        }

        #endregion
    }
}
