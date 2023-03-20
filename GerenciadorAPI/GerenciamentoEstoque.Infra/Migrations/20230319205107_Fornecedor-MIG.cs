using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FornecedorMIG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Fornecedor",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Fornecedor",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Cep",
                table: "Fornecedor",
                type: "int",
                maxLength: 8,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Fornecedor",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Fornecedor",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Fornecedor",
                type: "int",
                maxLength: 5,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "Fornecedor",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "Fornecedor");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Fornecedor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
