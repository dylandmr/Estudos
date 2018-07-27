using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class PessoaFisica : Cliente
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }
    }
}