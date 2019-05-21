using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.UI.Desktop
{
    public enum AcaoCrud
    {
        Nenhuma,
        Incluir,
        Alterar,
        Visualizar,
        Remover
    }

    public enum ChangePasswordViewType
    {
        Manual,
        NewUserForceNewPassword,
        ForgottenPassword
    }
}
