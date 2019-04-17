using System;

namespace Helpers
{
    public static class DateTimeExtensios
    {
        public static bool ValidateDataNascimento(this DateTime? dataNascimento, bool required = false)
        {
            if (dataNascimento == null)
                return !required;

            return ValidateDataNascimento(dataNascimento.GetValueOrDefault(), required);
        }

        public static bool ValidateDataNascimento(this DateTime dataNascimento, bool required = false)
        {
            if (dataNascimento == DateTime.MinValue)
                return !required;

            var anoCorrente = DateTime.Now.Year;
            var anoNascimento = dataNascimento.Year;

            return anoNascimento <= anoCorrente && anoNascimento > anoCorrente - 120;
        }
    }
}
