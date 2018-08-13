﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Interpreter.Exemplo___Calculadora
{
    public class Multiplicacao : IExpressao
    {
        public IExpressao Esquerda { get; private set; }
        public IExpressao Direita { get; private set; }

        public Multiplicacao(IExpressao esquerda, IExpressao direita)
        {
            Esquerda = esquerda;
            Direita = direita;
        }
        public int Avalia()
        {
            return Esquerda.Avalia() * Direita.Avalia();
        }
    }
}
