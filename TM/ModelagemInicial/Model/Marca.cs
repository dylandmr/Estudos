using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class Marca
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }
    }
}