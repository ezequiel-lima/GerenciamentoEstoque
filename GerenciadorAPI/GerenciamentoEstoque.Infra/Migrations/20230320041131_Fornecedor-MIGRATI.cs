using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FornecedorMIGRATI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoProduto");

            migrationBuilder.AddColumn<Guid>(
                name: "FornecedorId",
                table: "Pedido",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ItemPedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<long>(type: "BIGINT", precision: 0, nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemPedido_Produto_Id",
                        column: x => x.Id,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_FornecedorId",
                table: "Pedido",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_PedidoId",
                table: "ItemPedido",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Produto_Id",
                table: "Fornecedor",
                column: "Id",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Fornecedor_FornecedorId",
                table: "Pedido",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Produto_Id",
                table: "Fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Fornecedor_FornecedorId",
                table: "Pedido");

            migrationBuilder.DropTable(
                name: "ItemPedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_FornecedorId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Pedido");

            migrationBuilder.CreateTable(
                name: "PedidoProduto",
                columns: table => new
                {
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoProduto", x => new { x.PedidoId, x.ProdutosId });
                    table.ForeignKey(
                        name: "FK_PedidoProduto_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoProduto_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProduto_ProdutosId",
                table: "PedidoProduto",
                column: "ProdutosId");
        }
    }
}
