﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MatrixMax.Models
{
    public class Venda
    {
        public int Id { get; set; }

        public IList<ProdutosDaVenda> Produtos { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }
        public Pessoa Pessoa { get; set; }

        [Range(1,int.MaxValue)]
        public double ValorTotal { get; set; }

        public DateTime Data { get; set; }
        public int Parcelas { get; set; }
        public DateTime Previsao { get; set; }
        public string Observacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public string DescricaoStatus { get; set; }
        public int TipoStatusVenda { get; set; }
        public int TipoPagamento { get; set; }
        public int? DescontoPorcento { get; set; }
        public double DescontoValorFixo { get; set; }

        public Venda()
        {
            Produtos = new List<ProdutosDaVenda>();
        }

        public void IncluiProduto(Produto produto)
        {
            Produtos.Add(new ProdutosDaVenda() { Produto = produto });
        }
    }
}