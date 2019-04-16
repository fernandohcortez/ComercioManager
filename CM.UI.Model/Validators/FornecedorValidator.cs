using CM.UI.Model.Models;
using FluentValidation;

namespace CM.UI.Model.Validators
{
    public class FornecedorValidator : AbstractValidator<FornecedorModel>
    {
        public FornecedorValidator()
        {
            RuleFor(m => m.RazaoSocial)
                .NotEmpty().WithMessage("Razão Social é obrigatório.");

            RuleFor(m => m.Cnpj)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("CNPJ Obrigatório.")
                .Must(Validator.BeAValidCnpj).WithMessage("CNPJ Inválido.");
        }
    }
}
