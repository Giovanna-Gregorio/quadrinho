using Quadrinhos.Domain.Interfaces;
using Quadrinhos.Domain.Models;
using Quadrinhos.Repository.Data;

namespace Quadrinhos.Services
{
    public class VendaService : ServiceBase<Venda, int>, IVendaService
    {
        public VendaService(ApplicationDbContext db) : base(db)
        {
        }
    }
}
