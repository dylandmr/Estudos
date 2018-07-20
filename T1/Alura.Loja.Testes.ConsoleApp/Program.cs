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
            AtualizarProduto();
            //ExcluirProdutos();
            RecuperarProdutos();
        }

        private static void AtualizarProduto()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                Produto produto = repo.Produtos().First();
                produto.Nome = produto.Nome + " - Alterado!";

                repo.Atualizar(produto);
            }
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();
                foreach (var produto in produtos)
                {
                    repo.Remover(produto);
                }
            }
        }

        private static void RecuperarProdutos()
        {
            using (var contexto = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = contexto.Produtos();
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

            using (var contexto = new ProdutoDAOEntity())
            {
                contexto.Adicionar(p);
                contexto.Adicionar(p2);
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
