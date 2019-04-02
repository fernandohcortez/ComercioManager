using System.Runtime.Serialization;

namespace CM.UI.Model.Models
{
    [DataContract]
    public class ProdutoModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public decimal PrecoVenda { get; set; }
    }
}
