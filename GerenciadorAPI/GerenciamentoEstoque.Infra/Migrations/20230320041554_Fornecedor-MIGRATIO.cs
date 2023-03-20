using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FornecedorMIGRATIO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Produto_Id",
                table: "ItemPedido");

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "ItemPedido",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_ProdutoId",
                table: "ItemPedido",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Produto_ProdutoId",
                table: "ItemPedido",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Produto_ProdutoId",
                table: "ItemPedido");

            migrationBuilder.DropIndex(
                name: "IX_ItemPedido_ProdutoId",
                table: "ItemPedido");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ItemPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Produto_Id",
                table: "ItemPedido",
                column: "Id",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
