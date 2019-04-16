using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.UI.Model.Models;
using FluentValidation;

namespace CM.UI.Model.Validators
{
    public class ProdutoValidator : AbstractValidator<ProdutoModel>
    {
        public ProdutoValidator()
        {
            RuleFor(m => m.Nome).NotEmpty().WithMessage("Nome é obrigatório.");
        }
    }
}
