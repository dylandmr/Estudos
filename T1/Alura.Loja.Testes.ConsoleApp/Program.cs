using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            GravarUsandoEntity();
            RecuperarProdutos();
            ExcluirProdutos();
            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new LojaContext())
            {
                List<Produto> produtos = repo.Produtos.ToList();
                foreach (var produto in produtos)
                {
                    repo.Produtos.Remove(produto);
                }
                repo.SaveChanges();
            }
        }

        private static void RecuperarProdutos()
        {
            using (var contexto = new LojaContext())
            {
                List<Produto> produtos = contexto.Produtos.ToList();
                Console.WriteLine("{0} produtos na base.", produtos.Count);
                foreach (var produto in produtos)
                {
                    Console.WriteLine(produto.Nome);
                }
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Pai Rico, Pai Pobre";
            p.Categoria = "Livros";
            p.Preco = 40.50;

            Produto p2 = new Produto();
            p2.Nome = "Bacon";
            p2.Categoria = "Comida";
            p2.Preco = 3.32;

            using (var contexto = new LojaContext())
            {
                contexto.Produtos.AddRange(p, p2);
                contexto.SaveChanges();
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
