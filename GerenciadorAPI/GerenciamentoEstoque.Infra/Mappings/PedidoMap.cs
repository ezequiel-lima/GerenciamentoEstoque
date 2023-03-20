using GerenciamentoEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoEstoque.Infra.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataCriacao)
                .IsRequired();

            builder.Property(x => x.StatusPedido)
                .IsRequired();

            builder.HasOne(x => x.Fornecedor)
                .WithMany();

            builder.HasMany(x => x.ItensPedidos)
                .WithOne();
        }
    }
}
