using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public byte[] Senha { get; set; }
        public Pessoa Pessoa { get; set; }
        public byte[] ImagemDePerfil { get; set; }
    }
}