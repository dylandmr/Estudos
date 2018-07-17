using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Benner.AplicacaoCaixaEletronico.Contas;

namespace Benner.AplicacaoCaixaEletronico.Processamento
{
    class Banco
    {
        public Conta[] Contas { get; private set; }

        public Banco(int tamanho)
        {
            this.Contas = new Conta[tamanho];
        }

        public void Adiciona(Conta conta)
        {
            this.Contas[Conta.TotalDeContas] = conta;
        }
    }
}
