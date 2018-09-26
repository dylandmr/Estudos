﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MatrixMax.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public string Telefone { get; set; }

        public char TipoPessoa { get; set; }
        [MaxLength(50)]
        public string NomeRazaoSocial { get; set; }
        public string CpfCnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        [MaxLength(50)]
        public string NomeFantasia { get; set; }

        public Endereco Endereco { get; set; }
    }
}