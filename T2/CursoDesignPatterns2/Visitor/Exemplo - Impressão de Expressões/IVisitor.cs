using CursoDesignPatterns2.Interpreter.Exemplo___Calculadora;
using CursoDesignPatterns2.Interpreter.Exercício___Raiz_Quadrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Visitor.Exemplo___Impressão_de_Expressões
{
    public interface IVisitor
    {
        void ImprimeSoma(Soma soma);
        void ImprimeSubtracao(Subtracao subtracao);
        void ImprimeNumero(Numero numero);
        void ImprimeRaizQuadrada(RaizQuadrada raizquadrada);
        void ImprimeMultiplicacao(Multiplicacao multiplicacao);
        void ImprimeDivisao(Divisao divisao);
    }
}
