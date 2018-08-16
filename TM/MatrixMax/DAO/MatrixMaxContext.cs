using Microsoft.EntityFrameworkCore;
using System;

namespace MatrixMax.Models
{
    public class MatrixMaxContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<FormaDePagamento> FormasDePagamento { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Subcategoria> Subcategorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ProdutosDaVenda>()
                .HasKey(vp => new { vp.VendaId, vp.ProdutoId });

            modelBuilder
                .Entity<Endereco>()
                .Property<int>("PessoaId");

            modelBuilder
                .Entity<Endereco>()
                .HasKey("PessoaId");

            modelBuilder
                .Entity<Venda>()
                .Property(v => v.TipoStatusVenda)
                .HasDefaultValue(0);
        }

        public MatrixMaxContext()
        { }

        public MatrixMaxContext(DbContextOptions<MatrixMaxContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|MMDB.mdf;Integrated Security=True");
        }

    }
}