using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronicoV2
{
    class Cliente
    {
        public string nome;
        public string rg;
        public string endereço;
        public string cpf;
        public int idade;

        public bool MaiordeIdade()
        {
            //return idade >= 18 ? true : false; <- Minha solução, não eficiente. Solução do professor:
            return this.idade >= 18;
        }
    }
}
