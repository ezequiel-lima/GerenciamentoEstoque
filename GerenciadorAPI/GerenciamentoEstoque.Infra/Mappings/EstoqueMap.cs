using GerenciamentoEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoEstoque.Infra.Mappings
{
    public class EstoqueMap : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("Estoque");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProdutoId)
                .IsRequired();

            builder.Property(x => x.QuantidadeProduto)
                .IsRequired()
                .HasColumnType("BIGINT")
                .HasPrecision(0);
        }
    }
}
