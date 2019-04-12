using Caliburn.Micro;
using CM.UI.Model.Models;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProdutoEdicaoViewModel : Screen
    {
        #region Campos e Propriedades

        public bool IsViewSomenteLeitura { get; set; }
        public ProdutoModel ProdutoModel { get; set; }

        #endregion

        #region Construtores

        public static ProdutoEdicaoViewModel Create(bool somenteLeitura, ProdutoModel produtoModel)
        {
            var instancia = IoC.Get<ProdutoEdicaoViewModel>();

            instancia.ProdutoModel = produtoModel;
            instancia.IsViewSomenteLeitura = somenteLeitura;

            return instancia;
        }

        #endregion
    }
}
