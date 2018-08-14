using System;
using System.Collections.Generic;
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
        public double PrecoVenda { get; set; }
    }
}