using GerenciamentoEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoEstoque.Infra.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Telefone)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(15);

            builder.OwnsOne(x => x.Email)
                .Property(x => x.EnderecoEmail)
                .HasColumnName("Email")
                .HasMaxLength(200)
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Rua)
                .HasColumnName("Rua")
                .HasMaxLength(150)
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Bairro)
                .HasColumnName("Bairro")
                .HasMaxLength(150)
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Numero)
                .HasColumnName("Numero")
                .HasMaxLength(5)
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Cidade)
                .HasColumnName("Cidade")
                .HasMaxLength(100)
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Estado)
                .HasColumnName("Estado")
                .HasMaxLength(2)
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Cep)
                .HasColumnName("Cep")
                .HasMaxLength(8)
                .IsRequired();
        }
    }
}
