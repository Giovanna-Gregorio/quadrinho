using Microsoft.AspNetCore.Mvc;
using Quadrinhos.Domain.Contracts;
using Quadrinhos.Domain.Conts;
using Quadrinhos.Domain.Interfaces;
using Quadrinhos.Domain.Models;
using Quadrinhos.Domain.Result;
using Quadrinhos.Services;

namespace Quadrinhos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        protected readonly IUsuarioService _service;

        public LoginController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Login(LoginContract login)
        {
            var result = new ResultLogin();

            var usuario = _service.Login(login);

            if (usuario != null)
            {
                var token = TokenService.GenerateToken(usuario);

                result.Data = token;
                result.Message = Mensagens.SucessoLogin;

                return Ok(result);
            }

            result.Success = false;
            result.Message = Mensagens.ErroBusca;

            return Ok(result);
        }
    }
}
