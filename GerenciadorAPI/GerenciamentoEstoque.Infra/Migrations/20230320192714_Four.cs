using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EstoqueId",
                table: "Produto",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EstoqueId",
                table: "Pedido",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EstoqueId",
                table: "Fornecedor",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EstoqueId",
                table: "Produto",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_EstoqueId",
                table: "Pedido",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_EstoqueId",
                table: "Fornecedor",
                column: "EstoqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Estoque_EstoqueId",
                table: "Fornecedor",
                column: "EstoqueId",
                principalTable: "Estoque",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Estoque_EstoqueId",
                table: "Pedido",
                column: "EstoqueId",
                principalTable: "Estoque",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Estoque_EstoqueId",
                table: "Produto",
                column: "EstoqueId",
                principalTable: "Estoque",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Estoque_EstoqueId",
                table: "Fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Estoque_EstoqueId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Estoque_EstoqueId",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropIndex(
                name: "IX_Produto_EstoqueId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_EstoqueId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedor_EstoqueId",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "Fornecedor");
        }
    }
}
