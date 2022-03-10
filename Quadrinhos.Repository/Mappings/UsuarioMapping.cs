using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quadrinhos.Domain.Models;

namespace Quadrinhos.Repository.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(x => x.Id)
                .HasName("PK_usuario");

            builder.Property(x => x.Id)
                 .HasColumnName("id")
                 .UseIdentityColumn();

            builder.Property(x => x.Nome)
               .HasColumnName("nome");

            builder.Property(x => x.Email)
               .HasColumnName("email");

            builder.Property(x => x.Senha)
               .HasColumnName("senha");

            builder.Property(x => x.Role)
               .HasColumnName("role");
        }
    }
}
