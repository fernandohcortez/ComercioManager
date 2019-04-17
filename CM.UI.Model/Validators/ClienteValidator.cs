using CM.UI.Model.Models;
using CM.UI.Model.Validators.Custom;
using FluentValidation;

namespace CM.UI.Model.Validators
{
    public class ClienteValidator : AbstractValidator<ClienteModel>
    {
        public ClienteValidator()
        {
            RuleFor(m => m.Nome)
                .NotEmpty()
                .MaximumLength(70);

            RuleFor(m => m.Cpf)
                .IsAValidCpf();

            RuleFor(m => m.DataNascimento)
                .IsAValidDataNascimento();

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
