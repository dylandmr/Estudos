using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MatrixMax.Models
{
    public class Endereco
    {
        [MaxLength(50)]
        public string Logradouro { get; set; }

        public int? Numero { get; set; }
        public string Cep { get; set; }

        [MaxLength(100)]
        public string Referencia { get; set; }

        [MaxLength(50)]
        public string Bairro { get; set; }

        [MaxLength(50)]
        public string Complemento { get; set; }

        [MaxLength(50)]
        public string Cidade { get; set; }

        [MaxLength(50)]
        public string Estado { get; set; }

        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
    }
}