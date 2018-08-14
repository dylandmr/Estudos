using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public char TipoPessoa { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public string Email { get; set; }
        public int InscricaoSocial { get; set; }
    }
}