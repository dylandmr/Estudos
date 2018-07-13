using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoCaixaEletronico
{
    class ContaCorrente : Conta
    {
        public ContaCorrente(Cliente titular) : base(titular)
        {
            this.Titular = titular;
        }
    }
}
