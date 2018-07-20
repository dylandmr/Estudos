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

                ImprimeProdutos(produtos);
                Console.WriteLine("------------------------");
                foreach (var e in contexto.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.State);
                }

                var p = produtos.First();
                p.Nome = "Banana";
                ImprimeProdutos(produtos);

                Console.WriteLine("------------------------");
                foreach (var e in contexto.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.State);
                }

                contexto.SaveChanges();
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