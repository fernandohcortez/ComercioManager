using System.Runtime.Serialization;

namespace CM.UI.Model.Models
{
    [DataContract]
    public class AutenticarUsuario
    {
        [DataMember]
        public string Access_Token { get; set; }
        [DataMember]
        public string UserName { get; set; }
    }
}
