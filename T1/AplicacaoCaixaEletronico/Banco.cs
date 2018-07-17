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

        public void Remove(Conta conta)
        {
            int i;
            for (i = 0; i < Conta.TotalDeContas; i++)
            {
                if (this.Contas[i].Equals(conta)) break;
            }
            while (i+1 < Conta.TotalDeContas)
            {
                this.Contas[i] = this.Contas[i + 1];
                i++;
            }
            Conta.RemoveConta();
        }
    }
}
