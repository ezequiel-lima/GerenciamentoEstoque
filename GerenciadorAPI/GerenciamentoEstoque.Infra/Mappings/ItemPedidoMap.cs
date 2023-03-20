using GerenciamentoEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoEstoque.Infra.Mappings
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ItemPedido");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantidade)
                .IsRequired()
                .HasColumnType("BIGINT")
                .HasPrecision(0);

            builder.Property(x => x.PrecoUnitario)
                .IsRequired()
                .HasColumnType("DECIMAL(18,2)");

            builder.HasOne(x => x.Produto)
                .WithMany();
        }
    }
}
