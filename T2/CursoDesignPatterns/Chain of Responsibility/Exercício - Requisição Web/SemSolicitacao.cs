using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Chain_of_Responsibility.Exercício___Requisição_Web
{
    public class SemSolicitacao : ISolicitacao
    {
        public ISolicitacao Proxima { get; set; }

        public string Solicitacao(Conta conta, Requisicao requisicao)
        {
            return "NULO";
        }
    }
}
