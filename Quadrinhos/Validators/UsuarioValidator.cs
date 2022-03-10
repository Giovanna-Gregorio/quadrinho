using FluentValidation;
using Quadrinhos.Domain.Models;

namespace Quadrinhos.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Informe o nome");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Informe o email");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("Informe a senha");
        }
    }
}
