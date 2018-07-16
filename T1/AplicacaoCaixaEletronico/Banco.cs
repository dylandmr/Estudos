﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Benner.AplicacaoCaixaEletronico.Contas;

namespace Benner.AplicacaoCaixaEletronico.Processamento
{
    class Banco
    {
        private Conta[] contas = new Conta[10];

        public Conta[] Contas
        {
            get
            {
                return this.contas;
            }
        }

        public void Adiciona(Conta conta)
        {
            this.contas[Array.IndexOf(contas, null)] = conta;
        }
    }
}
