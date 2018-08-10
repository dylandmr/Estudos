using CursoDesignPatterns2.Factory.Exemplo___Conex�o_BD;
using CursoDesignPatterns2.Flyweight.Exemplo___Notas_Musicais;
using CursoDesignPatterns2.Flyweight.Singleton;
using CursoDesignPatterns2.Memento.Exemplo___Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2
{
    class Program
    {
        static void Main(string[] args)
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
