using CM.Domain.Helpers;
using CM.UI.Model.Attributes;
using PropertyChanged;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Serialization;

namespace CM.UI.Model.Models.Base
{
    [AddINotifyPropertyChangedInterface]
    [DataContract]
    public class ModelBase : ValidatableModelBase
    {
        [DataMember]
        [Browser(Title = "Código")]
        public string Id { get; set; }

        [DataMember]
        [Browser(Title = "Incluso em")]
        public DateTime DataInclusao { get; set; }

        [DataMember]
        [Browser(Title = "Alterado em")]
        public DateTime DataAlteracao { get; set; }

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        var property = GetType().GetProperty(columnName);

        //        if (property == null)
        //            return null;

        //        var attributes = property.GetCustomAttributes(typeof(RequiredAttribute), true);

        //        if (attributes.Length == 0)
        //            return null;

        //        foreach (var attribute in attributes)
        //        {
        //            if (!ValidarCampoObrigatorio(attribute, property, out var errorMessage))
        //                return errorMessage;
        //        }

        //        return null;
        //    }
        //}

        //protected virtual bool ValidarCampoObrigatorio(object attribute, PropertyInfo property, out string errorMessage)
        //{
        //    errorMessage = null;

        //    if (!(attribute is RequiredAttribute requiredAttribute))
        //        return true;

        //    if (string.IsNullOrEmpty(property.GetValue(this).IsNullThenEmpty()))
        //    {
        //        errorMessage = requiredAttribute.ErrorMessage;
        //        return false;
        //    }


        //    return true;
        //}
    }
}
