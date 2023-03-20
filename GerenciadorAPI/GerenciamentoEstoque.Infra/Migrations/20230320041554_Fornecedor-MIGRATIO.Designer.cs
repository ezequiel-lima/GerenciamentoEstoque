﻿// <auto-generated />
using System;
using GerenciamentoEstoque.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciamentoEstoque.Infra.Migrations
{
    [DbContext(typeof(GerenciamentoEstoqueDataContext))]
    [Migration("20230320041554_Fornecedor-MIGRATIO")]
    partial class FornecedorMIGRATIO
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Fornecedor", (string)null);
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.ItemPedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Quantidade")
                        .HasPrecision(0)
                        .HasColumnType("BIGINT");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItemPedido", (string)null);
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StatusPedido")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR");

                    b.Property<decimal>("Preco")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<long>("QuantidadeEmEstoque")
                        .HasPrecision(0)
                        .HasColumnType("BIGINT");

                    b.HasKey("Id");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Fornecedor", b =>
                {
                    b.HasOne("GerenciamentoEstoque.Domain.Entities.Produto", null)
                        .WithMany("Fornecedores")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("GerenciamentoEstoque.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("EnderecoEmail")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("Email");

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedor");

                            b1.WithOwner()
                                .HasForeignKey("FornecedorId");
                        });

                    b.OwnsOne("GerenciamentoEstoque.Domain.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)")
                                .HasColumnName("Bairro");

                            b1.Property<int>("Cep")
                                .HasMaxLength(8)
                                .HasColumnType("int")
                                .HasColumnName("Cep");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Cidade");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("nvarchar(2)")
                                .HasColumnName("Estado");

                            b1.Property<int>("Numero")
                                .HasMaxLength(5)
                                .HasColumnType("int")
                                .HasColumnName("Numero");

                            b1.Property<string>("Rua")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)")
                                .HasColumnName("Rua");

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedor");

                            b1.WithOwner()
                                .HasForeignKey("FornecedorId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.ItemPedido", b =>
                {
                    b.HasOne("GerenciamentoEstoque.Domain.Entities.Pedido", null)
                        .WithMany("ItensPedidos")
                        .HasForeignKey("PedidoId");

                    b.HasOne("GerenciamentoEstoque.Domain.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("GerenciamentoEstoque.Domain.Entities.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("ItensPedidos");
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Produto", b =>
                {
                    b.Navigation("Fornecedores");
                });
#pragma warning restore 612, 618
        }
    }
}
