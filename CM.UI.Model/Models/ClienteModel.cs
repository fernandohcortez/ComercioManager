using CM.UI.Model.Attributes;
using CM.UI.Model.Models.Base;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CM.UI.Model.Models
{
    public class ClienteModel : ModelBase
    {
        [DataMember]
        [Browser(WrapText = true)]
        [Required(ErrorMessage = "Obrigatório")]
        public string Nome { get; set; }

        [DataMember]
        [Browser(Title = "CPF", FixedWidth = 100, Alignment = BrowserAttributeAlignment.Center)]
        [Required(ErrorMessage = "Obrigatório")]
        public string Cpf { get; set; }

        [DataMember]
        [Browser(Title = "Data Nasc.", FixedWidth = 100)]
        public DateTime? DataNascimento { get; set; }

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
