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
        public int? SubcategoriaId { get; set; }
        public Marca Marca { get; set; }
        public int? MarcaId { get; set; }
        public bool Ativo { get; set; }
        public IList<ProdutosDaVenda> Vendas { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        public double PrecoUnitario { get; set; }
        
        public double? PrecoRecarga { get; set; }

        public double? PrecoTroca { get; set; }
        
        public Produto()
        {
            Vendas = new List<ProdutosDaVenda>();
        }
    }
}