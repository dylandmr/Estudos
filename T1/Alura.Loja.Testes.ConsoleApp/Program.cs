using Microsoft.EntityFrameworkCore.ChangeTracking;
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
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var produtos = contexto.Produtos.ToList();

                ImprimeChangeTracker(contexto.ChangeTracker.Entries());

                //var p = contexto.Produtos.ToList().First();

                //Console.Write("Alterar nome: ");
                //p.Nome = Console.ReadLine();

                //ImprimeChangeTracker(contexto.ChangeTracker.Entries());

                //contexto.SaveChanges();

                Console.WriteLine("Novo Produto - Nome [ENTER] - Preço [ENTER] - Categoria [ENTER] ");
                var novoP = new Produto()
                {
                    Nome = Console.ReadLine(),
                    Preco = Convert.ToDouble(Console.ReadLine()),
                    Categoria = Console.ReadLine()
                };

                contexto.Produtos.Add(novoP);
                contexto.Produtos.Remove(novoP);

                var entry = contexto.Entry(novoP);
                Console.WriteLine("\n\n---\n" + entry.Entity.ToString() + " - " + entry.State + "\n---\n\n");

                ImprimeChangeTracker(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();

                ImprimeChangeTracker(contexto.ChangeTracker.Entries());
            }

            void ImprimeChangeTracker(IEnumerable<EntityEntry> entries)
            {
                Console.WriteLine("------------------------");
                foreach (var e in entries)
                {
                    Console.WriteLine(e.Entity.ToString() + " - " +e.State);
                }
                Console.WriteLine("------------------------");
            }
        }        
    }
}