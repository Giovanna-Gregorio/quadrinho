using Microsoft.EntityFrameworkCore;
using Quadrinhos.Domain.Models;
using Quadrinhos.Repository.Mappings;

namespace Quadrinhos.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Quadrinho> Quadrinho { get; set; }

        public DbSet<Venda> Venda { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioMapping());
            builder.ApplyConfiguration(new QuadrinhoMapping());
            builder.ApplyConfiguration(new VendaMapping());
        }
    }
}
