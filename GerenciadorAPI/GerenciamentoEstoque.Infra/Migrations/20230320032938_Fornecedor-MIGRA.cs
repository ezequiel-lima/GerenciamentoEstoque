using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FornecedorMIGRA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Pedido_PedidoId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_PedidoId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Produto");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Pedido_Id",
                table: "Produto",
                column: "Id",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Pedido_Id",
                table: "Produto");

            migrationBuilder.AddColumn<Guid>(
                name: "PedidoId",
                table: "Produto",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_PedidoId",
                table: "Produto",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Pedido_PedidoId",
                table: "Produto",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id");
        }
    }
}
