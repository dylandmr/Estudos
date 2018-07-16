using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoCaixaEletronico
{
    class ContaCorrente : Conta
    {
        public static int TotalDeContas { get; private set; }

        public static int ProximaConta()
        {
            return ContaCorrente.TotalDeContas + 1;
        }
        public ContaCorrente(Cliente titular) : base(titular)
        {
            this.Titular = titular;
            this.Titular.Idade = 18;
            ContaCorrente.TotalDeContas++;
        }

        public override void Saca(double valor)
        {
            if (valor > this.Saldo) throw new SaldoInsuficienteException();
            else if (valor < 0) throw new ArgumentException();
            else if (!Titular.MaiordeIdade && valor > 200.0) throw new SaqueMenorDeIdadeException();
            else this.Saldo -= valor;
        }
    }
}
