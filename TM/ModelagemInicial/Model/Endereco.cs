using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class Endereco
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int Cep { get; set; }
        public string Referencia { get; set; }
        public string Bairro { get; set; }
    }
}