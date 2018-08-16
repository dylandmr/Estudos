using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelagemInicial.Migrations
{
    public partial class DescontosNaVendaEStatusDao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DescontoPorcento",
                table: "Vendas",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DescontoValorFixo",
                table: "Vendas",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescontoPorcento",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "DescontoValorFixo",
                table: "Vendas");
        }
    }
}
