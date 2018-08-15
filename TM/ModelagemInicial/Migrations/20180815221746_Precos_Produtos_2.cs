using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelagemInicial.Migrations
{
    public partial class Precos_Produtos_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrecoVenda",
                table: "Produtos",
                newName: "PrecoReciclado");

            migrationBuilder.AddColumn<double>(
                name: "PrecoPeriferico",
                table: "Produtos",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoPeriferico",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "PrecoReciclado",
                table: "Produtos",
                newName: "PrecoVenda");
        }
    }
}
