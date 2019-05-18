using System.Threading.Tasks;
using Caliburn.Micro;
using CM.UI.Desktop.ViewModels.Base;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models;
using CM.UI.Model.Validators;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class UsuarioViewModel : ViewModelBase<UsuarioListaViewModel, UsuarioEdicaoViewModel, UsuarioModel, UsuarioValidator>
    {
        #region Construtores

        public static UsuarioViewModel Create()
        {
            return IoC.Get<UsuarioViewModel>();
        }

        public UsuarioViewModel(IApiHelper apiHelper) : base(apiHelper)
        {

        }

        #endregion

        protected override async Task<UsuarioModel> SalvarInclusao()
        {
            const string password = "123mudar";

            return await ApiHelper.CriarNovaContaUsuario(password, password, RegistroCorrente);
        }

        protected override async Task RemoverRegistro()
        {
            await ApiHelper.RemoverContaUsuario(RegistroCorrente.Id);
        }
    }
}
