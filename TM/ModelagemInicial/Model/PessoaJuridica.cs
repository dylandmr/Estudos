using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class PessoaJuridica : Cliente
    {
        public int Cnpj { get; set; }

        public string RazaoSocial { get; set; }
    }
}