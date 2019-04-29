using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;
using Helpers;

namespace CM.UI.Desktop.Helpers
{
    public class StringToInscrEstadualConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var numero = value.ToString().RemoveNonNumeric();

            switch (numero.Length)
            {
                case 12:
                    return Regex.Replace(numero, @"(\d{3})(\d{3})(\d{3})(\d{3})", "$1.$2.$3-$4");
                default:
                    return numero;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString().RemoveNonNumeric();
        }
    }
}
