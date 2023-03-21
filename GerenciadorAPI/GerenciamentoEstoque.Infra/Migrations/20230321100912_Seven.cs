using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Seven : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Estoque_EstoqueId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Estoque_EstoqueId",
                table: "Venda");

            migrationBuilder.DropTable(
                name: "ItemVendaVenda");

            migrationBuilder.DropTable(
                name: "ItemVenda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_EstoqueId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Produto_EstoqueId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "QuantidadeEmEstoque",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Fornecedor",
                table: "Estoque");

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "Venda",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "Quantidade",
                table: "Venda",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "Estoque",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "QuantidadeProduto",
                table: "Estoque",
                type: "BIGINT",
                precision: 0,
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ProdutoId",
                table: "Venda",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Produto_ProdutoId",
                table: "Estoque",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Produto_ProdutoId",
                table: "Venda",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Produto_ProdutoId",
                table: "Estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Produto_ProdutoId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_ProdutoId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Estoque");

            migrationBuilder.DropColumn(
                name: "QuantidadeProduto",
                table: "Estoque");

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Venda",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "EstoqueId",
                table: "Venda",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Venda",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "EstoqueId",
                table: "Produto",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "QuantidadeEmEstoque",
                table: "Produto",
                type: "BIGINT",
                precision: 0,
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Fornecedor",
                table: "Estoque",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ItemVenda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Quantidade = table.Column<long>(type: "BIGINT", precision: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Produto_Id",
                        column: x => x.Id,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemVendaVenda",
                columns: table => new
                {
                    ItensVendasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVendaVenda", x => new { x.ItensVendasId, x.VendaId });
                    table.ForeignKey(
                        name: "FK_ItemVendaVenda_ItemVenda_ItensVendasId",
                        column: x => x.ItensVendasId,
                        principalTable: "ItemVenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemVendaVenda_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venda_EstoqueId",
                table: "Venda",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EstoqueId",
                table: "Produto",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendaVenda_VendaId",
                table: "ItemVendaVenda",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Estoque_EstoqueId",
                table: "Produto",
                column: "EstoqueId",
                principalTable: "Estoque",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Estoque_EstoqueId",
                table: "Venda",
                column: "EstoqueId",
                principalTable: "Estoque",
                principalColumn: "Id");
        }
    }
}
