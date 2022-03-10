using FluentValidation;
using Quadrinhos.Domain.Models;

namespace Quadrinhos.Validators
{
    public class QuadrinhoValidator : AbstractValidator<Quadrinho>
    {
        public QuadrinhoValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("Informe o título");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("Informe a descrição");

            RuleFor(x => x.Preco)
                .NotEmpty().WithMessage("Informe o preço");

            RuleFor(x => x.DataPublicacao)
                .NotEmpty().WithMessage("Informe a data de publicação");

            RuleFor(x => x.Escritor)
                .NotEmpty().WithMessage("Informe o escritor");

            RuleFor(x => x.QtdeEstoque)
                .NotEmpty().WithMessage("Informe a quantidade em estoque");
        }
    }
}
