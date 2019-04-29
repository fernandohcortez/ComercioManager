using System.Collections.ObjectModel;
using System.ComponentModel;
using Caliburn.Micro;
using CM.UI.Model.Models;
using PropertyChanged;
using Action = System.Action;

namespace CM.UI.Desktop.ViewModels.Base
{
    [AddINotifyPropertyChangedInterface]
    public class ListaViewModelBase<TModel> : Screen
    {
        #region Campos e Propriedades

        public Action ActionVisualizarRegistro;

        public ICollectionView ListaRegistros { get; set; }
        public TModel RegistroCorrente { get; set; }

        #endregion

        #region Ações Lista Registro

        public void CarregarRegistroCorrenteVisualizacao()
        {
            ActionVisualizarRegistro.Invoke();
        }

        #endregion
    }
}
