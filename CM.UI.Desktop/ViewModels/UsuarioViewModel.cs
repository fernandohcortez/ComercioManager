using Caliburn.Micro;
using CM.UI.Desktop.Components;
using CM.UI.Desktop.ViewModels.Base;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models;
using CM.UI.Model.Models.Interface;
using CM.UI.Model.Validators;
using PropertyChanged;
using System.Threading.Tasks;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class UsuarioViewModel : ViewModelBase<UsuarioListaViewModel, UsuarioEdicaoViewModel, UsuarioModel, UsuarioValidator>
    {
        private readonly UsuarioModel _usuarioModel;

        #region Construtores

        public static UsuarioViewModel Create()
        {
            return IoC.Get<UsuarioViewModel>();
        }

        public UsuarioViewModel(IApiHelper apiHelper, IUsuarioModel usuarioModel) : base(apiHelper)
        {
            _usuarioModel = usuarioModel as UsuarioModel;
        }

        #endregion

        protected override async Task<UsuarioModel> SalvarInclusao()
        {
            RegistroCorrente.Password = "123mudar";
            RegistroCorrente.ConfirmPassword = RegistroCorrente.Password;

            await ApiHelper.CriarNovaContaUsuario(RegistroCorrente);

            return await ApiHelper.Obter<UsuarioModel>(RegistroCorrente.Id);
        }

        protected override bool PreRemover()
        {
            if (RegistroCorrente.Id != _usuarioModel.Id)
                return true;

            Mensagem.Create().MostrarAlerta("Este usuário não pode ser removido porque é o usuário logado.\r\nSe deseja removê-lo, faça o login com outro usuário.");

            return false;
        }

        protected override async Task RemoverRegistro()
        {
            await ApiHelper.RemoverContaUsuario(RegistroCorrente.Id);
        }
    }
}
