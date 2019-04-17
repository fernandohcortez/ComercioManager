using CM.UI.Model.Models;
using FluentValidation;

namespace CM.UI.Model.Validators
{
    public class ProdutoValidator : AbstractValidator<ProdutoModel>
    {
        public ProdutoValidator()
        {
            RuleFor(m => m.Nome)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(m => m.PrecoVenda)
                .NotEmpty();
        }
    }
}
