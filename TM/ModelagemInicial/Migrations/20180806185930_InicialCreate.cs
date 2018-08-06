using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelagemInicial.Migrations
{
    public partial class InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaPeriferico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaPeriferico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rua = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Cep = table.Column<int>(nullable: false),
                    Referencia = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaDePagamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaDePagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarcaCartuchoToner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaCartuchoToner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarcaPeriferico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaPeriferico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCartuchoToner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCartuchoToner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    ImagemPerfil = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnderecoId = table.Column<int>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Preco = table.Column<double>(nullable: false),
                    Estoque = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Modelo = table.Column<string>(nullable: true),
                    MarcaCartuchoTonerId = table.Column<int>(nullable: true),
                    CategoriaPerifericoId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    MarcaPerifericoId = table.Column<int>(nullable: true),
                    Toner_Modelo = table.Column<string>(nullable: true),
                    Toner_MarcaCartuchoTonerId = table.Column<int>(nullable: true),
                    TipoCartuchoTonerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_MarcaCartuchoToner_MarcaCartuchoTonerId",
                        column: x => x.MarcaCartuchoTonerId,
                        principalTable: "MarcaCartuchoToner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_CategoriaPeriferico_CategoriaPerifericoId",
                        column: x => x.CategoriaPerifericoId,
                        principalTable: "CategoriaPeriferico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_MarcaPeriferico_MarcaPerifericoId",
                        column: x => x.MarcaPerifericoId,
                        principalTable: "MarcaPeriferico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_MarcaCartuchoToner_Toner_MarcaCartuchoTonerId",
                        column: x => x.Toner_MarcaCartuchoTonerId,
                        principalTable: "MarcaCartuchoToner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_TipoCartuchoToner_TipoCartuchoTonerId",
                        column: x => x.TipoCartuchoTonerId,
                        principalTable: "TipoCartuchoToner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recargas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true),
                    ValorTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recargas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recargas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: true),
                    FuncionarioId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormaDePagamentoId = table.Column<int>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false),
                    Parcelas = table.Column<int>(nullable: false),
                    Previsao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_FormaDePagamento_FormaDePagamentoId",
                        column: x => x.FormaDePagamentoId,
                        principalTable: "FormaDePagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Usuarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TiposCartucho",
                columns: table => new
                {
                    CartuchoId = table.Column<int>(nullable: false),
                    TipoCartuchoTonerId = table.Column<int>(nullable: false),
                    Preco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCartucho", x => new { x.TipoCartuchoTonerId, x.CartuchoId });
                    table.ForeignKey(
                        name: "FK_TiposCartucho_Produtos_CartuchoId",
                        column: x => x.CartuchoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiposCartucho_TipoCartuchoToner_TipoCartuchoTonerId",
                        column: x => x.TipoCartuchoTonerId,
                        principalTable: "TipoCartuchoToner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecargaCartucho",
                columns: table => new
                {
                    RecargaId = table.Column<int>(nullable: false),
                    CartuchoId = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecargaCartucho", x => new { x.RecargaId, x.CartuchoId });
                    table.ForeignKey(
                        name: "FK_RecargaCartucho_Produtos_CartuchoId",
                        column: x => x.CartuchoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecargaCartucho_Recargas_RecargaId",
                        column: x => x.RecargaId,
                        principalTable: "Recargas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendaProduto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false),
                    VendaId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaProduto", x => new { x.VendaId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_VendaProduto_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendaProduto_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EnderecoId",
                table: "Clientes",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_MarcaCartuchoTonerId",
                table: "Produtos",
                column: "MarcaCartuchoTonerId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaPerifericoId",
                table: "Produtos",
                column: "CategoriaPerifericoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_MarcaPerifericoId",
                table: "Produtos",
                column: "MarcaPerifericoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Toner_MarcaCartuchoTonerId",
                table: "Produtos",
                column: "Toner_MarcaCartuchoTonerId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_TipoCartuchoTonerId",
                table: "Produtos",
                column: "TipoCartuchoTonerId");

            migrationBuilder.CreateIndex(
                name: "IX_RecargaCartucho_CartuchoId",
                table: "RecargaCartucho",
                column: "CartuchoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recargas_ClienteId",
                table: "Recargas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposCartucho_CartuchoId",
                table: "TiposCartucho",
                column: "CartuchoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaProduto_ProdutoId",
                table: "VendaProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FormaDePagamentoId",
                table: "Vendas",
                column: "FormaDePagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FuncionarioId",
                table: "Vendas",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecargaCartucho");

            migrationBuilder.DropTable(
                name: "TiposCartucho");

            migrationBuilder.DropTable(
                name: "VendaProduto");

            migrationBuilder.DropTable(
                name: "Recargas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "MarcaCartuchoToner");

            migrationBuilder.DropTable(
                name: "CategoriaPeriferico");

            migrationBuilder.DropTable(
                name: "MarcaPeriferico");

            migrationBuilder.DropTable(
                name: "TipoCartuchoToner");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "FormaDePagamento");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
