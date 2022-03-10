using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quadrinhos.Domain.Models;

namespace Quadrinhos.Repository.Mappings
{
    public class QuadrinhoMapping : IEntityTypeConfiguration<Quadrinho>
    {
        public void Configure(EntityTypeBuilder<Quadrinho> builder)
        {
            builder.ToTable("quadrinho");

            builder.HasKey(x => x.Id)
                .HasName("PK_quadrinho");

            builder.Property(x => x.Id)
                 .HasColumnName("id")
                 .UseIdentityColumn();

            builder.Property(x => x.Titulo)
               .HasColumnName("titulo");

            builder.Property(x => x.Descricao)
               .HasColumnName("descricao");

            builder.Property(x => x.Preco)
               .HasColumnName("preco");

            builder.Property(x => x.DataPublicacao)
               .HasColumnName("publicacao");

            builder.Property(x => x.Escritor)
               .HasColumnName("escritor");

            builder.Property(x => x.QtdeEstoque)
               .HasColumnName("estoque");
        }
    }
}
