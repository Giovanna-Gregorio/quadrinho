using Microsoft.EntityFrameworkCore;
using Quadrinhos.Domain.Contracts;
using Quadrinhos.Domain.Interfaces;
using Quadrinhos.Domain.Models;
using Quadrinhos.Repository.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Quadrinhos.Services
{
    public class QuadrinhoService : ServiceBase<Quadrinho, int>, IQuadrinhoService
    {
        protected readonly IVendaService _vendaService;
        public QuadrinhoService(ApplicationDbContext db, IVendaService vendaService) : base(db)
        {
            _vendaService = vendaService;
        }

        public async Task<int> ComprarQuadrinho(CompraContract compra)
        {
            var venda = new Venda()
            {
                UsuarioId = 1,
                QuadrinhoId = compra.IdQuadrinho,
                Qtde = compra.Qtde
            };

            await _vendaService.Insert(venda);

            var quadrinho = base.Get(compra.IdQuadrinho)
                .AsNoTracking()
                .FirstOrDefault();

            quadrinho.QtdeEstoque -= compra.Qtde;

            return await base.Update(quadrinho);
        }
    }
}
