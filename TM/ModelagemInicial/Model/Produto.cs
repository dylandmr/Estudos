using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public abstract class Produto
    {
        public int Id { get; set; }

        public double Preco { get; set; }

        public int Estoque { get; set; }

        public Categoria Categoria { get; set; }

        public IList<VendaProduto> Vendas { get; set; }
    }
}