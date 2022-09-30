using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RegistroDependenciasGenericas.Model;

namespace RegistroDependenciasGenericas.Configuracao
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Descricao).HasMaxLength(80).IsRequired();
        }
    }
}

