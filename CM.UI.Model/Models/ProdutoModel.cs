using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CM.UI.Model.Models
{
    [DataContract]
    public class ProdutoModel
    {
        [DataMember]
        [DisplayName("Código")]
        public int Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [DataMember]
        [DisplayName("Preço")]
        public decimal PrecoVenda { get; set; }
        [DataMember]
        [DisplayName("Incluso em")]
        public DateTime DataInclusao { get; set; }
        [DataMember]
        [DisplayName("Alterado em")]
        public DateTime DataAlteracao { get; set; }
    }
}
