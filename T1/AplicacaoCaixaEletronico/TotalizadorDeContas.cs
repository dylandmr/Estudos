﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Benner.AplicacaoCaixaEletronico.Contas;

namespace Benner.AplicacaoCaixaEletronico.Processamento
{
    class TotalizadorDeContas
    {
        public double SaldoTotal { get; private set; }
        
        public void Adiciona(Conta c)
        {
            this.SaldoTotal += c.Saldo;
        }
    }
}
