using CursoDesignPatterns2.Factory.Exemplo___Conex�o_BD;
using CursoDesignPatterns2.Flyweight.Exemplo___Notas_Musicais;
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
