using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Quadrinhos.Domain.Conts;
using Quadrinhos.Domain.Interfaces;
using Quadrinhos.Domain.Models;
using System.Linq;

namespace Quadrinhos.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        private readonly IUsuarioService _service;
        private HttpContext _context;
        public UsuarioValidator(IUsuarioService service, IHttpContextAccessor httpContextAcessor)
        {
            _service = service;
            _context = httpContextAcessor.HttpContext;

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Informe o nome");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Informe o email")
                .Must(EmailExistente).WithMessage(Mensagens.EmailCadastrado);

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("Informe a senha");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Informe a função do usuário");
        }

        private bool EmailExistente(string email)
        {
            if (_context.Request.Method.ToUpper() == "POST")
                return _service.Get().Where(x => x.Email == email)
                    .AsNoTracking()
                    .FirstOrDefault() == null;

            return true;
        }
    }
}
