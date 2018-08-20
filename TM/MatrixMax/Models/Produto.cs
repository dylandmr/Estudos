﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MatrixMax.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int Estoque { get; set; }
        public Categoria Subcategoria { get; set; }
        public Marca Marca { get; set; }
        public char TipoProduto { get; set; }
        public IList<ProdutosDaVenda> Vendas { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }


        [DisplayFormat(DataFormatString = "R${0:#,##0.00#}", ApplyFormatInEditMode = true)]
        public double PrecoUnitario { get; set; }

        [DisplayFormat(DataFormatString = "R${0:#,##0.00#}", ApplyFormatInEditMode = true)]
        public double? PrecoRecarga { get; set; }

        [DisplayFormat(DataFormatString = "R${0:#,##0.00#}", ApplyFormatInEditMode = true)]
        public double? PrecoTroca { get; set; }
        
        public Produto()
        {
            Vendas = new List<ProdutosDaVenda>();
        }
    }
}