using Caliburn.Micro;
using CM.UI.Desktop.Components;
using CM.UI.Desktop.ViewModels.Base;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models;
using CM.UI.Model.Models.Interface;
using CM.UI.Model.Validators;
using PropertyChanged;
using System.Threading.Tasks;
using CM.UI.Desktop.Properties;

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
            RegistroCorrente.Password = Settings.Default.DefaultPassword;
            RegistroCorrente.ConfirmPassword = RegistroCorrente.Password;

            await ApiHelper.CriarContaUsuario(RegistroCorrente);

            return await ApiHelper.Obter<UsuarioModel>(RegistroCorrente.Id);
        }

        protected override async Task<UsuarioModel> SalvarAlteracao()
        {
            await ApiHelper.AlterarContaUsuario(RegistroCorrente);

            return await ApiHelper.Obter<UsuarioModel>(RegistroCorrente.Id);
        }

        protected override void PosSalvar(UsuarioModel model)
        {
            if (AcaoCrud == AcaoCrud.Incluir)
                Mensagem.Create().MostrarInformacao($"Usuário cadastrado com sucesso.\r\nA senha padrão é [{Settings.Default.DefaultPassword}] e deverá ser alterada no próximo login.");
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
