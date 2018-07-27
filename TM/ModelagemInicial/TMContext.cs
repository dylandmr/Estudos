using Microsoft.EntityFrameworkCore;
using System;

namespace ModelagemInicial
{
    public class TMContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Periferico> Perifericos { get; set; }
        public DbSet<Cartucho> Cartuchos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<VendaProduto>()
                .HasKey(vp => new { vp.VendaId, vp.ProdutoId });

            //modelBuilder
            //    .Entity<Endereco>()
            //    .ToTable("Enderecos");

            //modelBuilder
            //    .Entity<Endereco>()
            //    .Property<int>("ClienteId");

            //modelBuilder
            //    .Entity<Endereco>()
            //    .HasKey("ClienteId");
        }

        public TMContext()
        { }

        public TMContext(DbContextOptions<TMContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TMDB;Trusted_Connection=true;");
        }
    }
}