using CursoDesignPatterns2.Interpreter.Exemplo___Calculadora;
using CursoDesignPatterns2.Interpreter.Exercício___Raiz_Quadrada;
using CursoDesignPatterns2.Visitor.Exemplo___Impressão_de_Expressões;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Visitor.Exercício___Visitor_Pré_fixo
{
    public class ImpressoraPreFixaVisitor : IVisitor
    {
        public void ImprimeSoma(Soma soma)
        {
            Console.Write("(");
            Console.Write("+ ");
            soma.Esquerda.Aceita(this);
            Console.Write(" ");
            soma.Direita.Aceita(this);
            Console.Write(")");
        }

        public void ImprimeSubtracao(Subtracao subtracao)
        {
            Console.Write("(");
            Console.Write("- ");
            subtracao.Esquerda.Aceita(this);
            Console.Write(" ");
            subtracao.Direita.Aceita(this);
            Console.Write(")");
        }

        public void ImprimeNumero(Numero numero)
        {
            Console.Write(numero.Valor);
        }

        public void ImprimeRaizQuadrada(RaizQuadrada raizquadrada)
        {
            Console.Write("RaizQ(");
            raizquadrada.Numero.Aceita(this);
            Console.Write(")");
        }

        public void ImprimeMultiplicacao(Multiplicacao multiplicacao)
        {
            Console.Write("(");
            Console.Write("* ");
            multiplicacao.Esquerda.Aceita(this);            
            Console.Write(" ");
            multiplicacao.Direita.Aceita(this);
            Console.Write(")");
        }

        public void ImprimeDivisao(Divisao divisao)
        {
            Console.Write("(");
            Console.Write("/ ");
            divisao.Esquerda.Aceita(this);
            Console.Write(" ");
            divisao.Direita.Aceita(this);
            Console.Write(")");
        }
    }
}
