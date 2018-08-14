using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class ProdutosDaVenda
    {
        public int ProdutoId { get; set; }
        public int VendaId { get; set; }
        public int Quantidade { get; set; }
        public Venda Venda { get; set; }
        public Produto Produto { get; set; }
    }
}