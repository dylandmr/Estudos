using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelagemInicial.Migrations
{
    public partial class ProdutosVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosDasVendas_Produtos_ProdutoId",
                table: "ProdutosDasVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosDasVendas_Vendas_VendaId",
                table: "ProdutosDasVendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutosDasVendas",
                table: "ProdutosDasVendas");

            migrationBuilder.RenameTable(
                name: "ProdutosDasVendas",
                newName: "ProdutosDaVenda");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutosDasVendas_ProdutoId",
                table: "ProdutosDaVenda",
                newName: "IX_ProdutosDaVenda_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutosDaVenda",
                table: "ProdutosDaVenda",
                columns: new[] { "VendaId", "ProdutoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosDaVenda_Produtos_ProdutoId",
                table: "ProdutosDaVenda",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosDaVenda_Vendas_VendaId",
                table: "ProdutosDaVenda",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosDaVenda_Produtos_ProdutoId",
                table: "ProdutosDaVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosDaVenda_Vendas_VendaId",
                table: "ProdutosDaVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutosDaVenda",
                table: "ProdutosDaVenda");

            migrationBuilder.RenameTable(
                name: "ProdutosDaVenda",
                newName: "ProdutosDasVendas");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutosDaVenda_ProdutoId",
                table: "ProdutosDasVendas",
                newName: "IX_ProdutosDasVendas_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutosDasVendas",
                table: "ProdutosDasVendas",
                columns: new[] { "VendaId", "ProdutoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosDasVendas_Produtos_ProdutoId",
                table: "ProdutosDasVendas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosDasVendas_Vendas_VendaId",
                table: "ProdutosDasVendas",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
