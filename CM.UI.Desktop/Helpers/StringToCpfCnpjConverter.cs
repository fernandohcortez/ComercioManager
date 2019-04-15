using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace CM.UI.Desktop.Helpers
{
    public class StringToCpfCnpjConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            //retrieve only numbers in case we are dealing with already formatted phone no
            var numero = value.ToString().Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);

            switch (numero.Length)
            {
                case 11:
                    return Regex.Replace(numero, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
                case 14:
                    return Regex.Replace(numero, @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})", "$1.$2.$3/$4-$5");
                default:
                    return numero;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
