using Caliburn.Micro;
using CM.UI.Desktop.ViewModels.Base;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models;
using CM.UI.Model.Validators;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProdutoViewModel : ViewModelBase<ProdutoListaViewModel, ProdutoEdicaoViewModel, ProdutoModel, ProdutoValidator>
    {
        #region Construtores

        public static ProdutoViewModel Create()
        {
            return IoC.Get<ProdutoViewModel>();
        }

        public ProdutoViewModel(IApiHelper apiHelper) : base(apiHelper)
        {
            
        }

        #endregion
    }
}
