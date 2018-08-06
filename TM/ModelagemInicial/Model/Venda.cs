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
        public double ValorTotal { get; set; }
        public int Parcelas { get; set; }
        public DateTime Previsao { get; set; }

        public Venda()
        {
            Produtos = new List<VendaProduto>();
            ValorTotal = 0;
        }

        public void IncluiProduto(Produto produto, int quantidade)
        {
            Produtos.Add(new VendaProduto() { Produto = produto, Quantidade = quantidade });
            ValorTotal += produto.Preco * quantidade;
        }

        public void IncluiCartucho(Cartucho cartucho, double preco, int quantidade)
        {
            Produtos.Add(new VendaProduto { Produto = cartucho, Quantidade = quantidade });
            ValorTotal += preco * quantidade;
        }
    }
}