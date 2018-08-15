using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class Pessoa
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string NomeRazaoSocial { get; set; }

        [MaxLength(50)]
        public string NomeFantasia { get; set; }

        public string CpfCnpj { get; set; }
        public char TipoPessoa { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public string InscricaoEstadual { get; set; }
    }
}