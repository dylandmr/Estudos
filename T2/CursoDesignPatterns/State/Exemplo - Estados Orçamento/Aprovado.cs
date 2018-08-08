using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.State.Exemplo___Estados_Orçamento
{
    public class Aprovado : IEstadoDeUmOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            orcamento.Valor = orcamento.Valor - (orcamento.Valor * 0.02);
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Este já é o estado do orçamento.");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("O orçamento já foi aprovado.");
        }
    }
}
