using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MatrixMax.Models
{
    public class Subcategoria
    {
        public int Id { get; set; }

        [MaxLength(30), MinLength(5)]
        public string Nome { get; set; }

        public Categoria Categoria { get; set; }
    }
}