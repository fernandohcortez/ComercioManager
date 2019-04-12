using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using PropertyChanged;

namespace CM.UI.Model.Models.Base
{
    [AddINotifyPropertyChangedInterface]
    [DataContract]
    public class ModelBase
    {
        [DataMember]
        [DisplayName("Incluso em")]
        public DateTime DataInclusao { get; set; }
        [DataMember]
        [DisplayName("Alterado em")]
        public DateTime DataAlteracao { get; set; }
    }
}
