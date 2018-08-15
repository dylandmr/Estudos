using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class Produto
    {
        public int Id { get; set; }
        public int Estoque { get; set; }
        public Subcategoria Subcategoria { get; set; }
        public Marca Marca { get; set; }
        public char TipoProduto { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        [Range(1, int.MaxValue)]
        public double PrecoPeriferico { get; set; }

        [Range(1, int.MaxValue)]
        public double PrecoReciclado { get; set; }

        [Range(1, int.MaxValue)]
        public double PrecoTroca { get; set; }

        [Range(1, int.MaxValue)]
        public double PrecoRecarga { get; set; }

        [Range(1, int.MaxValue)]
        public double PrecoOriginal { get; set; }

        [Range(1, int.MaxValue)]
        public double PrecoCompativel { get; set; }
    }
}