using System;
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

        public override void Saca(double valor)
        {
            if (valor > this.Saldo) throw new SaldoInsuficienteException();
            else if (valor < 0) throw new ArgumentException();
            else if (!Titular.MaiordeIdade && valor > 200.0) throw new SaqueMenorDeIdadeException();
            else this.Saldo -= valor;
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
