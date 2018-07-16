using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Benner.AplicacaoCaixaEletronico.Contas;

namespace Benner.AplicacaoCaixaEletronico.Processamento
{
    class ContaComNome
    {
        public Conta Conta { get; set; }

        public String Nome { get { return Conta.Titular.Nome; } }

        public ContaComNome(Conta conta)
        {
            this.Conta = conta;
        }
    }
}
