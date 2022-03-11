using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Quadrinhos.Domain.Contracts;
using Quadrinhos.Domain.Interfaces;
using Quadrinhos.Domain.Models;
using Quadrinhos.Repository.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Quadrinhos.Services
{
    public class QuadrinhoService : ServiceBase<Quadrinho, int>, IQuadrinhoService
    {
        private readonly IHttpContextAccessor _accessor;
        protected readonly IVendaService _vendaService;
        public QuadrinhoService(ApplicationDbContext db, 
            IVendaService vendaService, IHttpContextAccessor accessor) : base(db)
        {
            _vendaService = vendaService;
            _accessor = accessor;
        }

        public async Task<int> ComprarQuadrinho(CompraContract compra)
        {
            var quadrinho = base.Get(compra.IdQuadrinho)
                .AsNoTracking()
                .FirstOrDefault();

            var usuarioId = _accessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;

            var venda = new Venda()
            {
                UsuarioId = Convert.ToInt32(usuarioId),
                QuadrinhoId = compra.IdQuadrinho,
                Qtde = compra.Qtde,
                ValorTotal = compra.Qtde * quadrinho.Preco
            };

            await _vendaService.Insert(venda);

            quadrinho.QtdeEstoque -= compra.Qtde;

            return await base.Update(quadrinho);
        }
    }
}
