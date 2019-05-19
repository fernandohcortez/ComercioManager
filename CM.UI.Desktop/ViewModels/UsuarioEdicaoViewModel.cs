using CM.UI.Desktop.Helpers;
using CM.UI.Desktop.ViewModels.Base;
using CM.UI.Model.Models;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class UsuarioEdicaoViewModel : EdicaoViewModelBase<UsuarioModel>
    {
        #region Campos e Propriedades

        #endregion

        public void SelecionarFoto()
        {
            var image = FileDialogBoxHelper.OpenDialogForImage();

            if (image != null)
                Model.Foto = image;
        }

        public void RemoverFoto()
        {
            Model.Foto = null;
        }
    }
}
