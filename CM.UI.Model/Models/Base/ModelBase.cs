using CM.UI.Model.Attributes;
using PropertyChanged;
using System;
using System.Runtime.Serialization;

namespace CM.UI.Model.Models.Base
{
    [AddINotifyPropertyChangedInterface]
    [DataContract]
    public class ModelBase : ValidatableModelBase
    {
        [DataMember]
        [Browser(Title = "Código")]
        public virtual string Id { get; set; }

        [DataMember]
        [Browser(Title = "Incluso em")]
        public DateTime DataInclusao { get; set; }

        [DataMember]
        [Browser(Title = "Alterado em")]
        public DateTime DataAlteracao { get; set; }
    }
}
