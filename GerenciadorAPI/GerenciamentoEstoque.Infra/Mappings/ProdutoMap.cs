using GerenciamentoEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoEstoque.Infra.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250);

            builder.Property(x => x.Preco)
                .IsRequired()
                .HasColumnType("DECIMAL(18,2)");

            builder.Property(x => x.QuantidadeEmEstoque)
                .IsRequired()
                .HasColumnType("BIGINT")
                .HasPrecision(0);

            builder.HasMany(x => x.Fornecedores)
                .WithMany();
        }
    }
}
