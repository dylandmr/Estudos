using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
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
