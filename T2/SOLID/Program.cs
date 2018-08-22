using SOLID.Acoplamento;
using SOLID.Single_Responsibility_Principle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            var acoes = new List<IAcaoAposGerarNota>()
            {
                new NotaFiscalDao(),
                new EnviadorDeEmail(),
                new EnviadorDeSMS()
            };
            
            var gerador = new GeradorDeNotaFiscal(acoes);
            var fatura = new Fatura(2000, "Fulano");
            var nf = gerador.Gera(fatura);
            Console.ReadKey();
        }

        private static void TestaSRPCalculadoraDeSalario()
        {
            var desenvolvedor = new Funcionario(new Desenvolvedor(new DezOuVintePorcento()), 2000);
            Console.WriteLine($"Um desenvolvedor com salário base de R${desenvolvedor.SalarioBase},00 receberá R${new CalculadoraDeSalario().Calcula(desenvolvedor)},00.");
            Console.ReadKey();
        }
    }
}