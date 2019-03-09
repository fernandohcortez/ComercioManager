using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace CMDataModel.Util
{
    public static class Extensions
    {
        public static string ExtrairNumeros(this string valor)
        {
            return string.Join(null, Regex.Split(valor, "[^\\d]"));
        }

        public static int IsNullThenZero(this string valor)
        {
            return string.IsNullOrEmpty(valor) ? 0 : int.Parse(valor);
        }

        public static string IsNullThenZeroString(this object valor)
        {
            return valor?.ToString() ?? "0";
        }

        public static int? IsNullThenZeroIntNull(this object valor)
        {
            var convertido = int.TryParse(valor.IsNullThenEmpty(), out var valorConvertido);

            return convertido ? valorConvertido : (int?)null;
        }

        public static string IsNullThenEmpty(this object valor)
        {
            return valor?.ToString() ?? string.Empty;
        }

        public static string IsNotNullThenInnerText(this XmlNode xmlNode)
        {
            return xmlNode?.InnerText ?? string.Empty;
        }

        public static string TrimAll(this string valor)
        {
            return valor == null ? string.Empty : Regex.Replace(valor, @"\s+", "");
        }

        public static string IsNullOrEmptyThenZero(this string valor)
        {
            return string.IsNullOrEmpty(valor) ? "0" : valor;
        }

        public static string ToUpperFirstLetter(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            var letters = source.ToLower().ToCharArray();

            letters[0] = char.ToUpper(letters[0]);

            return new string(letters);
        }

        public static DateTime IsNullOrEmptyThenMinValue(this string data)
        {
            return string.IsNullOrEmpty(data) ? DateTime.MinValue : Convert.ToDateTime(data);
        }
    }
}
