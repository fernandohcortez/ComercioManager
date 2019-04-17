using CM.UI.Model.Models;
using CM.UI.Model.Validators.Custom;
using FluentValidation;
using Helpers;

namespace CM.UI.Model.Validators
{
    public class FornecedorValidator : AbstractValidator<FornecedorModel>
    {
        public FornecedorValidator()
        {
            RuleFor(m => m.RazaoSocial)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(m => m.NomeFantasia)
                .MaximumLength(70);

            RuleFor(m => m.InscricaoEstadual)
                .MaximumLength(15);

            RuleFor(m => m.Cnpj)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .IsAValidCnpj();

            RuleFor(m => m.Estado)
                .IsAValidEstado();

            RuleFor(m => m.Email)
                .EmailAddress()
                .MaximumLength(256);

            RuleFor(m => m.Fone1)
                .IsAValidTelefone();

            RuleFor(m => m.Fone2)
                .IsAValidTelefone();

            RuleFor(m => m.Endereco)
                .MaximumLength(200);

            RuleFor(m => m.Complemento)
                .MaximumLength(100);

            RuleFor(m => m.Bairro)
                .MaximumLength(70);

            RuleFor(m => m.Cidade)
                .MaximumLength(70);
        }
    }
}
