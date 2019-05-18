using CM.UI.Model.Models.Base;
using System.ComponentModel;
using System.Runtime.Serialization;
using CM.UI.Model.Attributes;

namespace CM.UI.Model.Models
{
    public class ProdutoModel : ModelBase
    {
        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        [Browser(Title = "Descrição")]
        public string Descricao { get; set; }

        [DataMember]
        [Browser(Title = "Preço")]
        public decimal PrecoVenda { get; set; }
    }
}
