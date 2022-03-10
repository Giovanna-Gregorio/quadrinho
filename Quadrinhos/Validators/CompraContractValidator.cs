using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Quadrinhos.Domain.Contracts;
using Quadrinhos.Domain.Conts;
using Quadrinhos.Domain.Interfaces;
using System.Linq;

namespace Quadrinhos.Validators
{
    public class CompraContractValidator : AbstractValidator<CompraContract>
    {
        private readonly IQuadrinhoService _quadrinhoService;
        public CompraContractValidator(IQuadrinhoService quadrinhoService)
        {
            _quadrinhoService = quadrinhoService;

            RuleFor(x => x.IdQuadrinho)
                .NotEmpty().WithMessage("Informe o quadrinho");

            RuleFor(x => x.Qtde)
                .NotEmpty().WithMessage("Informe a quantidade");

            RuleFor(x => x)
                .Must(x => QuantidadeValida(x.Qtde)).WithMessage(Mensagens.QtdeInsuficiente);
        }

        private bool QuantidadeValida(int qtde)
        {
            var estoque = _quadrinhoService.Get(1).AsNoTracking().FirstOrDefault().QtdeEstoque;

            return estoque > qtde;
        }
    }
}
