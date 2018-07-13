using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoCaixaEletronico
{
    class ContaPoupanca : Conta
    {
        public ContaPoupanca(Cliente titular) : base(titular)
        {
            this.Titular = titular;
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
    }
}
