using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelagemInicial.Migrations
{
    public partial class PrecosENomeProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Produtos",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PrecoCompativel",
                table: "Produtos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrecoOriginal",
                table: "Produtos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrecoRecarga",
                table: "Produtos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrecoTroca",
                table: "Produtos",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PrecoCompativel",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PrecoOriginal",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PrecoRecarga",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PrecoTroca",
                table: "Produtos");
        }
    }
}
