using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.UI.Model.Models;
using FluentValidation;

namespace CM.UI.Model.Validators
{
    public class ClienteValidator : AbstractValidator<ClienteModel>
    {
        public ClienteValidator()
        {
            RuleFor(m => m.Nome).NotEmpty().WithMessage("Informe um {PropertyName}.");

            RuleFor(m => m.Cpf).Must(Validator.BeAValidCpf).WithMessage("Informe um CPF válido.");

            RuleFor(m => m.DataNascimento).Must(BeAValidDataNascimento).WithMessage("Informe uma data de nascimento válida.");

            RuleFor(m => m.Estado).Must(BeAValidEstado).WithMessage("Informe um estado válido.");

            RuleFor(m => m.Email).EmailAddress().WithMessage("Informe um email válido.");
        }

        protected bool BeAValidDataNascimento(DateTime? dataNascimento)
        {
            if (dataNascimento == null)
                return true;

            var anoCorrente = DateTime.Now.Year;
            var anoNascimento = dataNascimento.GetValueOrDefault().Year;

            return anoNascimento <= anoCorrente && anoNascimento > anoCorrente - 120;
        }

        protected bool BeAValidEstado(string estado)
        {
            if (string.IsNullOrEmpty(estado))
                return true;

            return new ListaEstadoModel().Estados.Any(m => m.Estado == estado);
        }
    }

    
}
