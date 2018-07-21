using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
                //var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                //var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                //loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var produtos = contexto.Produtos.ToList();
                //ImprimeProdutos(produtos);
                ImprimeChangeTracker(contexto);

                var p = produtos.First();
                Console.Write("Alterar nome: ");
                p.Nome = Console.ReadLine();
                //ImprimeProdutos(produtos);
                ImprimeChangeTracker(contexto);
                contexto.SaveChanges();

                Console.WriteLine("Novo Produto - Nome [ENTER] - Preço [ENTER] - Categoria [ENTER] ");
                var novoP = new Produto()
                {
                    Nome = Console.ReadLine(),
                    Preco = Convert.ToDouble(Console.ReadLine()),
                    Categoria = Console.ReadLine()
                };
                contexto.Produtos.Add(novoP);
                ImprimeChangeTracker(contexto);
                contexto.SaveChanges();
            }

            //void ImprimeProdutos(IList<Produto> prods)
            //{
            //    Console.WriteLine("------------------------");
            //    foreach (var p in prods)
            //    {
            //        Console.WriteLine(p);
            //    }
            //    Console.WriteLine("------------------------");
            //}

            void ImprimeChangeTracker(LojaContext contexto)
            {
                Console.WriteLine("------------------------");
                foreach (var e in contexto.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.Entity.ToString() + " - " +e.State);
                }
                Console.WriteLine("------------------------");
            }
        }        
    }
}