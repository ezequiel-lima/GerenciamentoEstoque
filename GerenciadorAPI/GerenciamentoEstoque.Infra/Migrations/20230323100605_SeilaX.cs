using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SeilaX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProdutoNome",
                table: "Estoque",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutoNome",
                table: "Estoque");
        }
    }
}
