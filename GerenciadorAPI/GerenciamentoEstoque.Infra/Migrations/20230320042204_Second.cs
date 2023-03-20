using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Produto_Id",
                table: "Fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Pedido_PedidoId",
                table: "ItemPedido");

            migrationBuilder.DropIndex(
                name: "IX_ItemPedido_PedidoId",
                table: "ItemPedido");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "ItemPedido");

            migrationBuilder.CreateTable(
                name: "FornecedorProduto",
                columns: table => new
                {
                    FornecedoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecedorProduto", x => new { x.FornecedoresId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_FornecedorProduto_Fornecedor_FornecedoresId",
                        column: x => x.FornecedoresId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FornecedorProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPedidoPedido",
                columns: table => new
                {
                    ItensPedidosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedidoPedido", x => new { x.ItensPedidosId, x.PedidoId });
                    table.ForeignKey(
                        name: "FK_ItemPedidoPedido_ItemPedido_ItensPedidosId",
                        column: x => x.ItensPedidosId,
                        principalTable: "ItemPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPedidoPedido_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorProduto_ProdutoId",
                table: "FornecedorProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidoPedido_PedidoId",
                table: "ItemPedidoPedido",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FornecedorProduto");

            migrationBuilder.DropTable(
                name: "ItemPedidoPedido");

            migrationBuilder.AddColumn<Guid>(
                name: "PedidoId",
                table: "ItemPedido",
                type: "uniqueidentifier",
                nullable: true);

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
                name: "FK_ItemPedido_Pedido_PedidoId",
                table: "ItemPedido",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id");
        }
    }
}
