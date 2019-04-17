using System;

namespace Helpers
{
    public static class ObjectExternsions
    {
        public static int? IsNullThenZeroIntNull(this object valor)
        {
            var convertido = int.TryParse(valor.IsNullThenEmpty(), out var valorConvertido);

            return convertido ? valorConvertido : (int?)null;
        }

        public static int IsNullOrEmptyThenZero(this object valor)
        {
            var convertido = int.TryParse(valor.IsNullThenEmpty(), out var valorConvertido);

            return convertido ? valorConvertido : 0;
        }

        public static string IsNullThenEmpty(this object valor)
        {
            return valor?.ToString() ?? string.Empty;
        }

        public static string IsNullThenZeroString(this object valor)
        {
            return valor?.ToString() ?? "0";
        }
    }
}
