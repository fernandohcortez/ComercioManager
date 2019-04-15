using System;
using CM.UI.Model.Models.Base;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CM.UI.Model.Models
{
    public class FornecedorModel : ModelBase
    {
        [DataMember]
        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; }
        [DataMember]
        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }
        [DataMember]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }
        [DataMember]
        [DisplayName("Insc. Est.")]
        public string InscricaoEstadual { get; set; }
        [DataMember]
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        [DataMember]
        public string Complemento { get; set; }
        [DataMember]
        public string Bairro { get; set; }
        [DataMember]
        public string Cidade { get; set; }
        [DataMember]
        [DisplayName("UF")]
        public string Estado { get; set; }
        [DataMember]
        [DisplayName("Fone 1")]
        public string Fone1 { get; set; }
        [DataMember]
        [DisplayName("Fone 2")]
        public string Fone2 { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}
