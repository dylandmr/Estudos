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
            using (var contexto = new LojaContext())
            {
                var produtos = contexto.Produtos.ToList();

                ImprimeProdutos(produtos);

                var p = produtos.First();
                p.Nome = "Chocolate";
                contexto.SaveChanges();

                ImprimeProdutos(produtos);

                Console.WriteLine("------------------------");
                foreach (var e in contexto.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.State);
                }
            }

            void ImprimeProdutos(IList<Produto> prods)
            {
                Console.WriteLine("------------------------");
                    
                foreach (var p in prods)
                {
                    Console.WriteLine(p);
                }
            }
        }        
    }
}