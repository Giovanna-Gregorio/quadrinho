using Quadrinhos.Domain.Contracts;
using Quadrinhos.Domain.Models;
using System.Threading.Tasks;

namespace Quadrinhos.Domain.Interfaces
{
    public interface IQuadrinhoService : IServiceBase<Quadrinho, int>
    {
        Task<int> ComprarQuadrinho(CompraContract compra);
    }
}
