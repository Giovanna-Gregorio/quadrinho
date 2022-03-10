using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quadrinhos.Domain.Contracts;
using Quadrinhos.Domain.Conts;
using Quadrinhos.Domain.Interfaces;
using Quadrinhos.Domain.Models;
using Quadrinhos.Domain.Result;
using Quadrinhos.Extensions;
using System.Threading.Tasks;

namespace Quadrinhos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuadrinhoController : BaseController<Quadrinho, int>
    {
        protected readonly IQuadrinhoService _service;
        public QuadrinhoController(IQuadrinhoService service) : base(service)
        {
            _service = service;
        }

        [Authorize(Roles = "cliente")]
        [HttpPost("compra")]
        public virtual async Task<IActionResult> PostCompra([FromBody] CompraContract compra)
        {
            var result = new ResultBase<Quadrinho>();

            var validateResult = this.ValidateModelState<CompraContract>(Mensagens.ErroInserir);

            if (validateResult != null)
                return Ok(validateResult);

            var quadrinho = await _service.ComprarQuadrinho(compra);

            if (quadrinho > 0)
            {
                result.Data = null;
                result.Message = Mensagens.SucessoCompra;

                return Ok(result);
            }

            result.Success = false;
            result.Message = Mensagens.ErroCompra;

            return Ok(result);
        }

        [Authorize(Roles = "adm")]
        [HttpPost]
        public override async Task<IActionResult> Post([FromBody] Quadrinho model)
        {
            return await base.Post(model);
        }

        [Authorize(Roles = "adm")]
        [HttpPut()]
        public override async Task<IActionResult> Put(Quadrinho model)
        {
            return await base.Put(model);
        }

        [Authorize(Roles = "adm")]
        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}
