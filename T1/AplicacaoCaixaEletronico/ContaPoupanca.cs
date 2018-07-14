﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoCaixaEletronico
{
    class ContaPoupanca : Conta, ITributavel
    {
        public ContaPoupanca(Cliente titular) : base(titular)
        {
            this.Titular = titular;
            this.Titular.Idade = 18;
        }

        public override bool Saca(double valor)
        {
            if (valor <= this.Saldo && valor > 0)
            {
                if (!Titular.MaiordeIdade && valor > 200.0) this.Saldo -= 200.0 + 0.1;
                else this.Saldo -= valor + 0.1;
                return true;
            }
            else return false;
        }

        public override void Deposita(double valor)
        {
            if (valor > 0) this.Saldo += valor - 0.1;
        }

        public double CalculaTributos()
        {
            return this.Saldo * 0.02;
        }
    }
}
