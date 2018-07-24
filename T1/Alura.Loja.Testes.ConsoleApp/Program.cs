using Microsoft.EntityFrameworkCore;
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
            var fulano = new Cliente();
            fulano.Nome = "Fulano de Tal";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Logradouro = "Rua São Paulo",
                Numero = "593",
                Complemento = "Casa 2",
                Bairro = "Centro",
                Cidade = "Blumenau"
            };

            using (var contexto = new LojaContext())
            {
                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }
        }

        private static void ImprimeChangeTracker(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("------------------------");
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
            Console.WriteLine("------------------------");
        }

        private static void MuitosParaMuitos()
        {
            var chocolate = new Produto() { Nome = "Chocolate", Categoria = "Doce", PrecoUnitario = 4.5, Unidade = "Gramas" };
            var bala = new Produto() { Nome = "Bala", Categoria = "Doce", PrecoUnitario = 0.05, Unidade = "Unidade" };
            var caneta = new Produto() { Nome = "Caneta", Categoria = "Material", PrecoUnitario = 0.5, Unidade = "Unidade" };

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Alegre";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);
            promocaoDePascoa.IncluiProduto(chocolate);
            promocaoDePascoa.IncluiProduto(bala);
            promocaoDePascoa.IncluiProduto(caneta);

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var promo = contexto.Promocoes.Find(1);

                contexto.Promocoes.Remove(promo);

                contexto.SaveChanges();
            }
        }
    }
}