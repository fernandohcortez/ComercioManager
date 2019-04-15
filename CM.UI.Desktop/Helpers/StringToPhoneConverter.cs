using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace CM.UI.Desktop.Helpers
{
    public class StringToPhoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            //retrieve only numbers in case we are dealing with already formatted phone no
            var phoneNo = value.ToString().Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty).Replace("-", string.Empty).Replace("+", string.Empty);

            switch (phoneNo.Length)
            {
                case 8:
                    return Regex.Replace(phoneNo, @"(\d{4})(\d{4})", "$1-$2");
                case 10:
                    return Regex.Replace(phoneNo, @"(\d{2})(\d{4})(\d{4})", "($1)$2-$3");
                case 11:
                    return Regex.Replace(phoneNo, @"(\d{2})(\d{5})(\d{4})", "($1)$2-$3");
                case 13:
                    return Regex.Replace(phoneNo, @"(\d{2})(\d{2})(\d{4})(\d{4})", "+$1-($2)-$3-$4");
                case 14:
                    return Regex.Replace(phoneNo, @"(\d{2})(\d{2})(\d{5})(\d{4})", "+$1-($2)-$3-$4");
                default:
                    return phoneNo;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
