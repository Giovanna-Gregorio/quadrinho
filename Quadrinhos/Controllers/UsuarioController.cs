using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quadrinhos.Domain.Interfaces;
using Quadrinhos.Domain.Models;
using System.Threading.Tasks;

namespace Quadrinhos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController<Usuario, int>
    {
        public UsuarioController(IUsuarioService service) : base(service)
        {

        }

        [Authorize(Roles = "adm")]
        [HttpGet]
        public override IActionResult Get([FromQuery] int limit = 0, int offset = 0)
        {
            return base.Get(limit, offset);
        }

        [Authorize]
        [HttpGet("{id}")]
        public override IActionResult GetById(int id)
        {
            return base.GetById(id);
        }

        [Authorize]
        [HttpPut()]
        public override async Task<IActionResult> Put(Usuario model)
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
