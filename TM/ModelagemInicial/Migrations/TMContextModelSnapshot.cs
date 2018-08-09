﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelagemInicial;

namespace ModelagemInicial.Migrations
{
    [DbContext(typeof(TMContext))]
    partial class TMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModelagemInicial.CategoriaPeriferico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("CategoriaPeriferico");
                });

            modelBuilder.Entity("ModelagemInicial.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("EnderecoId");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Clientes");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Cliente");
                });

            modelBuilder.Entity("ModelagemInicial.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<int>("Cep");

                    b.Property<int>("Numero");

                    b.Property<string>("Referencia");

                    b.Property<string>("Rua");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("ModelagemInicial.FormaDePagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("FormaDePagamento");
                });

            modelBuilder.Entity("ModelagemInicial.MarcaCartuchoToner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("MarcaCartuchoToner");
                });

            modelBuilder.Entity("ModelagemInicial.MarcaPeriferico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("MarcaPeriferico");
                });

            modelBuilder.Entity("ModelagemInicial.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Estoque");

                    b.Property<double>("Preco");

                    b.HasKey("Id");

                    b.ToTable("Produtos");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Produto");
                });

            modelBuilder.Entity("ModelagemInicial.Recarga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId");

                    b.Property<DateTime>("DataEntrega");

                    b.Property<int>("Status");

                    b.Property<double>("ValorTotal");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Recargas");
                });

            modelBuilder.Entity("ModelagemInicial.RecargaCartucho", b =>
                {
                    b.Property<int>("RecargaId");

                    b.Property<int>("CartuchoId");

                    b.Property<double>("Valor");

                    b.HasKey("RecargaId", "CartuchoId");

                    b.HasIndex("CartuchoId");

                    b.ToTable("RecargaCartucho");
                });

            modelBuilder.Entity("ModelagemInicial.TipoCartuchoToner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("TipoCartuchoToner");
                });

            modelBuilder.Entity("ModelagemInicial.TiposCartucho", b =>
                {
                    b.Property<int>("TipoCartuchoTonerId");

                    b.Property<int>("CartuchoId");

                    b.Property<double>("Preco");

                    b.HasKey("TipoCartuchoTonerId", "CartuchoId");

                    b.HasIndex("CartuchoId");

                    b.ToTable("TiposCartucho");
                });

            modelBuilder.Entity("ModelagemInicial.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("ImagemPerfil");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("ModelagemInicial.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId");

                    b.Property<DateTime>("Data");

                    b.Property<int?>("FormaDePagamentoId");

                    b.Property<int?>("FuncionarioId");

                    b.Property<int>("Parcelas");

                    b.Property<DateTime>("Previsao");

                    b.Property<double>("ValorTotal");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FormaDePagamentoId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("ModelagemInicial.VendaProduto", b =>
                {
                    b.Property<int>("VendaId");

                    b.Property<int>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.HasKey("VendaId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("VendaProduto");
                });

            modelBuilder.Entity("ModelagemInicial.PessoaFisica", b =>
                {
                    b.HasBaseType("ModelagemInicial.Cliente");

                    b.Property<string>("Cpf");

                    b.Property<string>("Nome");

                    b.ToTable("PessoaFisica");

                    b.HasDiscriminator().HasValue("PessoaFisica");
                });

            modelBuilder.Entity("ModelagemInicial.PessoaJuridica", b =>
                {
                    b.HasBaseType("ModelagemInicial.Cliente");

                    b.Property<string>("Cnpj");

                    b.Property<string>("RazaoSocial");

                    b.ToTable("PessoaJuridica");

                    b.HasDiscriminator().HasValue("PessoaJuridica");
                });

            modelBuilder.Entity("ModelagemInicial.Cartucho", b =>
                {
                    b.HasBaseType("ModelagemInicial.Produto");

                    b.Property<int?>("MarcaCartuchoTonerId");

                    b.Property<string>("Modelo");

                    b.HasIndex("MarcaCartuchoTonerId");

                    b.ToTable("Cartucho");

                    b.HasDiscriminator().HasValue("Cartucho");
                });

            modelBuilder.Entity("ModelagemInicial.Periferico", b =>
                {
                    b.HasBaseType("ModelagemInicial.Produto");

                    b.Property<int?>("CategoriaPerifericoId");

                    b.Property<int?>("MarcaPerifericoId");

                    b.Property<string>("Nome");

                    b.HasIndex("CategoriaPerifericoId");

                    b.HasIndex("MarcaPerifericoId");

                    b.ToTable("Periferico");

                    b.HasDiscriminator().HasValue("Periferico");
                });

            modelBuilder.Entity("ModelagemInicial.Toner", b =>
                {
                    b.HasBaseType("ModelagemInicial.Produto");

                    b.Property<int?>("MarcaCartuchoTonerId")
                        .HasColumnName("Toner_MarcaCartuchoTonerId");

                    b.Property<string>("Modelo")
                        .HasColumnName("Toner_Modelo");

                    b.Property<int?>("TipoCartuchoTonerId");

                    b.HasIndex("MarcaCartuchoTonerId");

                    b.HasIndex("TipoCartuchoTonerId");

                    b.ToTable("Toner");

                    b.HasDiscriminator().HasValue("Toner");
                });

            modelBuilder.Entity("ModelagemInicial.Administrador", b =>
                {
                    b.HasBaseType("ModelagemInicial.Usuario");


                    b.ToTable("Administrador");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("ModelagemInicial.Funcionario", b =>
                {
                    b.HasBaseType("ModelagemInicial.Usuario");


                    b.ToTable("Funcionario");

                    b.HasDiscriminator().HasValue("Funcionario");
                });

            modelBuilder.Entity("ModelagemInicial.Cliente", b =>
                {
                    b.HasOne("ModelagemInicial.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");
                });

            modelBuilder.Entity("ModelagemInicial.Recarga", b =>
                {
                    b.HasOne("ModelagemInicial.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("ModelagemInicial.RecargaCartucho", b =>
                {
                    b.HasOne("ModelagemInicial.Cartucho", "Cartucho")
                        .WithMany("Recargas")
                        .HasForeignKey("CartuchoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ModelagemInicial.Recarga", "Recarga")
                        .WithMany("Cartuchos")
                        .HasForeignKey("RecargaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ModelagemInicial.TiposCartucho", b =>
                {
                    b.HasOne("ModelagemInicial.Cartucho", "Cartucho")
                        .WithMany("Tipos")
                        .HasForeignKey("CartuchoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ModelagemInicial.TipoCartuchoToner", "TipoCartuchoToner")
                        .WithMany("Cartuchos")
                        .HasForeignKey("TipoCartuchoTonerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ModelagemInicial.Venda", b =>
                {
                    b.HasOne("ModelagemInicial.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("ModelagemInicial.FormaDePagamento", "FormaDePagamento")
                        .WithMany()
                        .HasForeignKey("FormaDePagamentoId");

                    b.HasOne("ModelagemInicial.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");
                });

            modelBuilder.Entity("ModelagemInicial.VendaProduto", b =>
                {
                    b.HasOne("ModelagemInicial.Produto", "Produto")
                        .WithMany("Vendas")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ModelagemInicial.Venda", "Venda")
                        .WithMany("Produtos")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ModelagemInicial.Cartucho", b =>
                {
                    b.HasOne("ModelagemInicial.MarcaCartuchoToner", "MarcaCartuchoToner")
                        .WithMany()
                        .HasForeignKey("MarcaCartuchoTonerId");
                });

            modelBuilder.Entity("ModelagemInicial.Periferico", b =>
                {
                    b.HasOne("ModelagemInicial.CategoriaPeriferico", "CategoriaPeriferico")
                        .WithMany()
                        .HasForeignKey("CategoriaPerifericoId");

                    b.HasOne("ModelagemInicial.MarcaPeriferico", "MarcaPeriferico")
                        .WithMany()
                        .HasForeignKey("MarcaPerifericoId");
                });

            modelBuilder.Entity("ModelagemInicial.Toner", b =>
                {
                    b.HasOne("ModelagemInicial.MarcaCartuchoToner", "MarcaCartuchoToner")
                        .WithMany()
                        .HasForeignKey("MarcaCartuchoTonerId");

                    b.HasOne("ModelagemInicial.TipoCartuchoToner", "TipoCartuchoToner")
                        .WithMany()
                        .HasForeignKey("TipoCartuchoTonerId");
                });
#pragma warning restore 612, 618
        }
    }
}