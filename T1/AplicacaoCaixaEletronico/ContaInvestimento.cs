using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoCaixaEletronico
{
    class ContaInvestimento : Conta, ITributavel
    {
        public ContaInvestimento(Cliente titular) : base(titular)
        {
            this.Titular = titular;
            this.Titular.Idade = 18;
        }

        public double CalculaTributos()
        {
            return this.Saldo * 0.03;
        }

        public override bool Saca(double valor)
        {
            if (valor <= this.Saldo && valor > 0)
            {
                if (!Titular.MaiordeIdade && valor > 200.0) this.Saldo -= 200.0;
                else this.Saldo -= valor;
                return true;
            }
            else return false;
        }
    }
}
