using CM.UI.Model.Models;
using FluentValidation;

namespace CM.UI.Model.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioModel>
    {
        public UsuarioValidator()
        {
            RuleFor(m => m.Id)
                .MaximumLength(256);

            RuleFor(m => m.PrimeiroNome)
                .NotEmpty()
                .MaximumLength(70);

            RuleFor(m => m.UltimoNome)
                .NotEmpty()
                .MaximumLength(70);

            RuleFor(m => m.Email)
                .EmailAddress()
                .MaximumLength(256);
        }
    }
}
