using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quadrinhos.Domain.Models;

namespace Quadrinhos.Repository.Mappings
{
    public class VendaMapping : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("venda");

            builder.HasKey(x => x.Id)
                .HasName("PK_venda");

            builder.Property(x => x.Id)
                 .HasColumnName("id")
                 .UseIdentityColumn();

            builder.Property(x => x.UsuarioId)
               .HasColumnName("usuario_id");

            builder.Property(x => x.QuadrinhoId)
               .HasColumnName("quadrinho_id");

            builder.Property(x => x.Qtde)
               .HasColumnName("qtde");

            builder.Property(x => x.ValorTotal)
               .HasColumnName("valor_total");

            builder.Property(x => x.DataInclusao)
               .HasColumnName("data_inclusao");

            builder.HasOne(d => d.Usuario)
               .WithMany(p => p.Vendas)
               .HasForeignKey(d => d.UsuarioId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Quadrinho)
               .WithMany(p => p.Vendas)
               .HasForeignKey(d => d.QuadrinhoId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
