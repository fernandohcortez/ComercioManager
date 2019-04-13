using Caliburn.Micro;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels.Base
{
    [AddINotifyPropertyChangedInterface]
    public class EdicaoViewModelBase<TModel> : Screen
    {
        #region Campos e Propriedades

        public bool IsViewSomenteLeitura { get; set; }
        public TModel Model { get; set; }

        #endregion
    }
}
