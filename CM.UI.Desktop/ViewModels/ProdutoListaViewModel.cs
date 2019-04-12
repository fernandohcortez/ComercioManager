using Caliburn.Micro;
using CM.UI.Model.Models;
using PropertyChanged;
using System.Collections.ObjectModel;
using Action = System.Action;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProdutoListaViewModel : Screen
    {
        #region Campos e Propriedades

        private Action _actionVisualizarRegistro;

        public ObservableCollection<ProdutoModel> ListaRegistros { get; set; }
        public ProdutoModel RegistroCorrente { get; set; }

        #endregion

        #region Construtores

        public static ProdutoListaViewModel Create(Action actionVisualizarRegistro)
        {
            var instancia = IoC.Get<ProdutoListaViewModel>();
            instancia._actionVisualizarRegistro = actionVisualizarRegistro;

            return instancia;
        }

        #endregion

        #region Ações Lista Registro

        public void CarregarRegistroCorrenteVisualizacao()
        {
            _actionVisualizarRegistro.Invoke();
        }

        #endregion
    }
}
