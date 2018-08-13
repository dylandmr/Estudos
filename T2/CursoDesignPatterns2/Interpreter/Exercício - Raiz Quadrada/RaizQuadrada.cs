using CursoDesignPatterns2.Interpreter.Exemplo___Calculadora;
using CursoDesignPatterns2.Visitor.Exemplo___Impressão_de_Expressões;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Interpreter.Exercício___Raiz_Quadrada
{
    public class RaizQuadrada : IExpressao
    {
        private IExpressao numero;

        public RaizQuadrada(IExpressao numero)
        {
            this.numero = numero;
        }

        public void Aceita(ImpressoraVisitor impressora)
        {
            throw new NotImplementedException();
        }
        

        public int Avalia()
        {
            return (int)Math.Sqrt(numero.Avalia());
        }

        public void Aceita(IVisitor impressora)
        {
            throw new NotImplementedException();
        }
    }
}
