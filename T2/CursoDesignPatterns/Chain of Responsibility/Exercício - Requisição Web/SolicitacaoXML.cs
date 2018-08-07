using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CursoDesignPatterns.Chain_of_Responsibility.Exercício___Requisição_Web
{
    public class SolicitacaoXML : ISolicitacao
    {
        public ISolicitacao Proxima { get; set; }

        public string Solicitacao(Conta conta, Requisicao requisicao)
        {
            if (requisicao.Formato.Equals(Formato.XML))
            {
                return $"<conta>\n\t<titular>{conta.Titular}</titular>\n\t<saldo>{conta.Saldo}<saldo>\n</conta>";
            }
            return Proxima.Solicitacao(conta, requisicao);
        }
    }
}
