using CursoDesignPatterns.Chain_of_Responsibility.Exemplo___Descontos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestaChainOfResponsibilityDescontos();
        }

        private static void TestaChainOfResponsibilityDescontos()
        {
            CalculadorDeDescontos calculador = new CalculadorDeDescontos();

            Orcamento orcamento = new Orcamento(500);
            orcamento.AdicionaItem(new Item("Qualquer coisa", 100));
            orcamento.AdicionaItem(new Item("Qualquer coisa", 100));
            orcamento.AdicionaItem(new Item("Qualquer coisa", 100));
            orcamento.AdicionaItem(new Item("Qualquer coisa", 100));
            orcamento.AdicionaItem(new Item("Qualquer coisa", 100));


            double desconto = calculador.Calcula(orcamento);

            Console.WriteLine(desconto);

            Console.ReadKey();
        }

        private static void TestaStrategyImpostoEInvesitmento()
        {
            var iss = new ISS();
            var icms = new ICMS();
            var iccc = new ICCC();

            var orcamento = new Orcamento(500);

            var calculador = new CalculadorDeImpostos();

            calculador.RealizaCalculo(orcamento, icms);
            calculador.RealizaCalculo(orcamento, iss);
            calculador.RealizaCalculo(orcamento, iccc);

            Console.ReadKey();

            var conta = new Conta();
            conta.Deposita(500);

            var investidor = new RealizadorDeInvestimentos();

            var conservador = new Conservador();
            var moderado = new Moderado();
            var arrojado = new Arrojado();

            investidor.RealizaInvestimento(conta, conservador);
            investidor.RealizaInvestimento(conta, moderado);
            investidor.RealizaInvestimento(conta, arrojado);

            Console.ReadKey();
        }
    }
}
