using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Six : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Produto_ProdutoId",
                table: "ItemVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Venda_VendaId",
                table: "ItemVenda");

            migrationBuilder.DropIndex(
                name: "IX_ItemVenda_ProdutoId",
                table: "ItemVenda");

            migrationBuilder.DropIndex(
                name: "IX_ItemVenda_VendaId",
                table: "ItemVenda");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ItemVenda");

            migrationBuilder.DropColumn(
                name: "VendaId",
                table: "ItemVenda");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotal",
                table: "Venda",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Cliente",
                table: "Venda",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "Quantidade",
                table: "ItemVenda",
                type: "BIGINT",
                precision: 0,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoUnitario",
                table: "ItemVenda",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
                name: "IX_ItemVendaVenda_VendaId",
                table: "ItemVendaVenda",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Produto_Id",
                table: "ItemVenda",
                column: "Id",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Produto_Id",
                table: "ItemVenda");

            migrationBuilder.DropTable(
                name: "ItemVendaVenda");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotal",
                table: "Venda",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Cliente",
                table: "Venda",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "ItemVenda",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT",
                oldPrecision: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoUnitario",
                table: "ItemVenda",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "ItemVenda",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VendaId",
                table: "ItemVenda",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_ProdutoId",
                table: "ItemVenda",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_VendaId",
                table: "ItemVenda",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Produto_ProdutoId",
                table: "ItemVenda",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Venda_VendaId",
                table: "ItemVenda",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "Id");
        }
    }
}
