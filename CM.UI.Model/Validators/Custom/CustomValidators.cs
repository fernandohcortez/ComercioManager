using System;
using CM.UI.Model.Models;
using FluentValidation;
using Helpers;
using System.Collections.Generic;
using System.Linq;

namespace CM.UI.Model.Validators.Custom
{
    public static class MyCustomValidators
    {
        public static IRuleBuilderOptions<T, string> IsAValidEstado<T>(this IRuleBuilder<T, string> ruleBuilder, bool required = false)
        {
            return ruleBuilder.Must(m => new ListaEstadoModel().ValidateEstado(m.IsNullThenEmpty(), required)).WithMessage("Informe um estado válido.");
        }

        public static IRuleBuilderOptions<T, string> IsAValidCpf<T>(this IRuleBuilder<T, string> ruleBuilder, bool required = false)
        {
            return ruleBuilder.Must(m => m.IsNullThenEmpty().ValidateCpf(required)).WithMessage("Informe um CPF válido.");
        }

        public static IRuleBuilderOptions<T, string> IsAValidCnpj<T>(this IRuleBuilder<T, string> ruleBuilder, bool required = false)
        {
            return ruleBuilder.Must(m => m.IsNullThenEmpty().ValidateCnpj(required)).WithMessage("Informe um CNPJ válido.");
        }

        public static IRuleBuilderOptions<T, DateTime> IsAValidDataNascimento<T>(this IRuleBuilder<T, DateTime> ruleBuilder, bool required = false)
        {
            return ruleBuilder.Must(m => m.ValidateDataNascimento(required)).WithMessage("Informe uma data de nascimento válida.");
        }

        public static IRuleBuilderOptions<T, DateTime?> IsAValidDataNascimento<T>(this IRuleBuilder<T, DateTime?> ruleBuilder, bool required = false)
        {
            return ruleBuilder.Must(m => m.ValidateDataNascimento(required)).WithMessage("Informe uma data de nascimento válida.");
        }

        public static IRuleBuilderOptions<T, string> IsAValidTelefone<T>(this IRuleBuilder<T, string> ruleBuilder, bool required = false)
        {
            return ruleBuilder.Must(m => m.ValidatePhoneNumber(required)).WithMessage("Informe um telefone válido.");
        }

    }
}
