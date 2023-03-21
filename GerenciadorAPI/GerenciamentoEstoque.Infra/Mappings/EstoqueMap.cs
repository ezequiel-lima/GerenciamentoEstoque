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

            builder.HasOne(x => x.Produto)
                .WithMany();

            builder.Property(x => x.QuantidadeProduto)
                .IsRequired()
                .HasColumnType("BIGINT")
                .HasPrecision(0);
        }
    }
}
