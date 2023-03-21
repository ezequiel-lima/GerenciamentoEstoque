using GerenciamentoEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoEstoque.Infra.Mappings
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Venda");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Produto)
                .WithMany();

            builder.Property(x => x.Data)
                .IsRequired();

            builder.Property(x => x.Quantidade)
                .IsRequired()
                .HasColumnType("BIGINT");

            builder.HasOne(x => x.Produto)
                .WithMany();
        }
    }
}
