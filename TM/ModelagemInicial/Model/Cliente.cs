using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public abstract class Cliente
    {
        public int Id { get; set; }
        public Endereco Endereco { get; set; }
        public string Telefone { get; set; }
    }
}