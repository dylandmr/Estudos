using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Chain_of_Responsibility.Exercício___Requisição_Web
{
    public class ProcessadorDeSolicitacao
    {
        public string Processa(Conta conta, Requisicao requisicao)
        {
            var s1 = new SolicitacaoCSV();
            var s2 = new SolicitacaoPorcento();
            var s3 = new SolicitacaoXML();
            var s4 = new SemSolicitacao();

            s1.Proxima = s2;
            s2.Proxima = s3;
            s3.Proxima = s4;

            return s1.Solicitacao(conta, requisicao);
        }
    }
}
