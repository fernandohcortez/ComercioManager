using System;
using System.Text.RegularExpressions;

namespace Helpers
{
    public static class StringExtensions
    {
        public static int IsNullThenZero(this string valor)
        {
            return string.IsNullOrEmpty(valor) ? 0 : int.Parse(valor);
        }

        public static string TrimAll(this string valor)
        {
            return valor == null ? string.Empty : Regex.Replace(valor, @"\s+", "");
        }

        public static string IsNullOrEmptyThenZero(this string valor)
        {
            return string.IsNullOrEmpty(valor) ? "0" : valor;
        }

        public static DateTime IsNullOrEmptyThenMinValue(this string data)
        {
            return string.IsNullOrEmpty(data) ? DateTime.MinValue : Convert.ToDateTime(data);
        }

        public static string ToUpperFirstLetter(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            var letters = source.ToLower().ToCharArray();

            letters[0] = char.ToUpper(letters[0]);

            return new string(letters);
        }

        public static string RemoveNonNumeric(this string text)
        {
            return Regex.Replace(text, @"[^0-9]+", "");
        }

        public static bool ValidateEmail(this string email, bool required = false)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    return !required;

                var address = new System.Net.Mail.MailAddress(email);

                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidateCnpj(this string cnpj, bool required = false)
        {
            cnpj = cnpj.IsNullThenEmpty().Trim();

            var multiplicador1 = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.RemoveNonNumeric();

            if (string.IsNullOrEmpty(cnpj))
                return !required;

            if (cnpj.Length != 14)
                return false;

            var tempCnpj = cnpj.Substring(0, 12);

            var soma = 0;

            for (var i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            var resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            soma = 0;

            for (var i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto;

            return cnpj.EndsWith(digito);
        }

        public static bool ValidateCpf(this string cpf, bool required = false)
        {
            cpf = cpf.IsNullThenEmpty().Trim();

            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.RemoveNonNumeric();

            if (string.IsNullOrEmpty(cpf))
                return !required;

            if (cpf.Length != 11)
                return false;

            var tempCpf = cpf.Substring(0, 9);

            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            var resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto;

            return cpf.EndsWith(digito);
        }

        public static bool ValidatePhoneNumber(this string phone, bool required = false)
        {
            if (string.IsNullOrEmpty(phone))
                return !required;

            var phoneNo = phone.RemoveNonNumeric();

            return phoneNo.Length == 8 || phoneNo.Length == 10 || phoneNo.Length == 11 || phoneNo.Length == 13 || phoneNo.Length == 14;
        }
    }
}
