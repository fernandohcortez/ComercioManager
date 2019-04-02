using System;
using System.Runtime.Serialization;
using CM.UI.Model.Models.Interface;

namespace CM.UI.Model.Models
{
    [DataContract]
    public class UsuarioLogadoModel : IUsuarioLogadoModel
    {
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string PrimeiroNome { get; set; }
        [DataMember]
        public string UltimoNome { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public DateTime DataInclusao { get; set; }
    }
}
