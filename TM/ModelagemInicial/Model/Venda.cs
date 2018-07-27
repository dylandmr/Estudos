using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class Venda
    {
        public Cliente Cliente { get; set; }

        public Funcionario Funcionario { get; set; }

        public int Id { get; set; }

        public IList<VendaProduto> Produtos { get; set; }

        public FormaDePagamento FormaDePagamento { get; set; }

        public DateTime Data { get; set; }

        public Venda()
        {
            this.Produtos = new List<VendaProduto>();
        }

        internal void IncluiProduto(Produto produto)
        {
            this.Produtos.Add(new VendaProduto() { Produto = produto });
        }
    }
}