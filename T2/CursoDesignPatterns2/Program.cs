using CursoDesignPatterns2.Factory.Exemplo___Conexão_BD;
using CursoDesignPatterns2.Flyweight.Exemplo___Notas_Musicais;
using CursoDesignPatterns2.Flyweight.Singleton;
using CursoDesignPatterns2.Interpreter.Exemplo___Calculadora;
using CursoDesignPatterns2.Interpreter.Exercício___Raiz_Quadrada;
using CursoDesignPatterns2.Memento.Exemplo___Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2
{
    class Program 
    {
        static void Main(string[] args)
        {
            var raizDeNove = new RaizQuadrada(new Numero(9));

            Console.WriteLine(raizDeNove.Avalia());

            Console.ReadKey();
        }

        private static void TestaInterpreterExemploMultiplicacao()
        {
            var esquerda = new Divisao(new Divisao(new Numero(8), new Numero(2)), new Numero(2)); // (8/2) / 2 = 4 / 2 = 2
            var direita = new Multiplicacao(new Numero(3), new Numero(2)); // 3 * 2 = 6
            Console.WriteLine(new Multiplicacao(esquerda, direita).Avalia()); // 2 * 6 = 12

            Console.ReadKey();
        }

        private static void TestaInterpreterExemploSomaSubtracao()
        {
            var esquerda = new Soma(new Soma(new Numero(1), new Numero(100)), new Numero(10)); // (1+100) + 10 = 111
            var direita = new Subtracao(new Numero(20), new Numero(10)); // 20 - 10 = 10
            Console.WriteLine(new Soma(esquerda, direita).Avalia()); // 111 + 10 = 121

            Console.ReadKey();
        }

        private static void TestaInterpreterInternoExpressions()
        {
            //Interpreter interno do C#:
            var soma = Expression.Add(Expression.Constant(10), Expression.Constant(20));
            var funcao = Expression.Lambda<Func<int>>(soma).Compile();
            Console.WriteLine(funcao());

            Console.ReadKey();
        }

        private static void TestaMemementoContratos()
        {
            var historico = new Historico();

            var contrato = new Contrato(DateTime.Now, "Titular", TipoContrato.Novo);
            historico.Adiciona(contrato.SalvaEstado());

            Console.ReadKey();

            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());

            Console.ReadKey();

            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());

            Console.ReadKey();

            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());

            Console.WriteLine(contrato.Tipo);

            Console.ReadKey();

            Console.WriteLine($"{historico.Recupera(0).Contrato.Tipo} - {historico.Recupera(0).AdicionadoEm.ToString()}");
            Console.WriteLine($"{historico.Recupera(1).Contrato.Tipo} - {historico.Recupera(1).AdicionadoEm.ToString()}");
            Console.WriteLine($"{historico.Recupera(2).Contrato.Tipo} - {historico.Recupera(2).AdicionadoEm.ToString()}");

            Console.ReadKey();
        }

        private static void TestandoSingleton()
        {
            var singleton = Singleton.Instancia;
            Console.ReadKey();
        }

        private static void TestandoFlyweightNotasMusicais()
        {
            var criadordenotas = new NotasMusicais();

            var notas = new List<INota>()
            {
                criadordenotas.PegaNota("do"),
                criadordenotas.PegaNota("re"),
                criadordenotas.PegaNota("mi"),
                criadordenotas.PegaNota("fa"),
                criadordenotas.PegaNota("sol"),
                criadordenotas.PegaNota("la"),
                criadordenotas.PegaNota("si"),
            };

            var piano = new Piano();

            piano.Toca(notas);
        }

        private static void ExemploFactoryConexaoBD()
        {
            var conexao = new ConnectionFactory().GetConnection();
            var comando = conexao.CreateCommand();
            comando.CommandText = "SELECT * FROM Tabela";

            Console.ReadKey();
        }
    }
}
