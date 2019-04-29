using System;
using CM.UI.Model.Models.Base;
using System.ComponentModel;
using System.Runtime.Serialization;
using CM.UI.Model.Attributes;

namespace CM.UI.Model.Models
{
    public class FornecedorModel : ModelBase
    {
        [DataMember]
        [Browser(Title = "Razão Social", WrapText = true)]
        public string RazaoSocial { get; set; }

        [DataMember]
        [Browser(Title = "Nome Fantasia", WrapText = true, FixedWidth = 100)]
        public string NomeFantasia { get; set; }

        [DataMember]
        [Browser(Title = "CNPJ", FixedWidth = 120, Alignment = BrowserAttributeAlignment.Center)]
        public string Cnpj { get; set; }

        [DataMember]
        [Browser(Title = "Inscr. Est.", Visible = false)]
        public string InscricaoEstadual { get; set; }

        [DataMember]
        [Browser(Title = "Endereço", Visible = false)]
        public string Endereco { get; set; }

        [DataMember]
        [Browser(Visible = false)]
        public string Complemento { get; set; }

        [DataMember]
        [Browser(Visible = false)]
        public string Bairro { get; set; }

        [DataMember]
        [Browser(Visible = false)]
        public string Cidade { get; set; }

        [DataMember]
        [Browser(Title = "UF", Visible = false)]
        public string Estado { get; set; }

        [DataMember]
        [Browser(Title = "Fone 1", Visible = false)]
        public string Fone1 { get; set; }

        [DataMember]
        [Browser(Title = "Fone 2", Visible = false)]
        public string Fone2 { get; set; }

        [DataMember]
        [Browser(Visible = false)]
        public string Email { get; set; }
    }
}
