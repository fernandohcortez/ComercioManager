using System;
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
        public ObservableCollection<ProdutoModel> ListaRegistros { get; set; }

        public ProdutoModel RegistroSelecionado { get; set; }

        private Action _actionVisualizarRegistro;

        public static ProdutoListaViewModel Create(Action actionVisualizarRegistro)
        {
            var instancia = IoC.Get<ProdutoListaViewModel>();
            instancia._actionVisualizarRegistro = actionVisualizarRegistro;

            return instancia;
        }

        public ProdutoListaViewModel()
        {

        }

        public void AbrirRegistroVisualizacao()
        {
            _actionVisualizarRegistro.Invoke();
            //var conductor = Parent as IConductor;
            //conductor?.ActivateItem(ProdutoEdicaoViewModel.Create(true, RegistroSelecionado));
        }
    }
}
