using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class Periferico : Produto
    {
        public CategoriaPeriferico CategoriaPeriferico { get; set; }

        public string Nome { get; set; }
    }
}