using CM.UI.Model.Attributes;
using CM.UI.Model.Models.Base;
using CM.UI.Model.Models.Interface;
using System.Runtime.Serialization;

namespace CM.UI.Model.Models
{
    public class UsuarioModel : ModelBase, IUsuarioModel
    {
        [DataMember]
        [Browser(Title = "Usuário", WrapText = true, FixedWidth = 250, Alignment = BrowserAttributeAlignment.Left)]
        public override string Id { get; set; }

        [DataMember]
        [Browser(Visible = false)]
        public string Token { get; set; }

        [DataMember]
        [Browser(Title = "Primeiro Nome", FixedWidth = 130, WrapText = true)]
        public string PrimeiroNome { get; set; }

        [DataMember]
        [Browser(Title = "Último Nome", FixedWidth = 130, WrapText = true)]
        public string UltimoNome { get; set; }

        [DataMember]
        [Browser(WrapText = true)]
        public string Email { get; set; }

        [DataMember]
        [Browser(Visible = false)]
        public byte[] Foto { get; set; }

        [DataMember]
        [Browser(Visible = false)]
        public bool Administrador { get; set; }

        [DataMember]
        [Browser(Visible = false)]
        public string Password { get; set; }

        [DataMember]
        [Browser(Visible = false)]
        public string ConfirmPassword { get; set; }
    }
}
