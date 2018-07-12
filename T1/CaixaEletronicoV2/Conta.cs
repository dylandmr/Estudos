﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronicoV2
{
    class Conta
    {
        public int numero;
        public double saldo;
        public int agencia;
        public Cliente titular;

        public void Saca(double valor)
        {
            if (valor <= this.saldo && valor > 0) this.saldo -= valor;
        }

        public void Deposita(double valor)
        {
            if (valor > 0) this.saldo += valor;
        }

        public void Transfere(double valor, Conta destino)
        {
            this.Saca(valor);
            destino.Deposita(valor);
        }

        public double RendimentoAnual()
        {
            double saldoprevisto = this.saldo;
            for (int i = 0; i < 12; i++) saldoprevisto *= 1.007;
            return (saldoprevisto - this.saldo);
        }
    }
}
