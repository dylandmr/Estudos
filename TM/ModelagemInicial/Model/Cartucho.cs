using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class Cartucho : Produto
    {
        public MarcaCartucho MarcaCartucho { get; set; }

        public string Modelo { get; set; }

        public TipoCartucho TipoCartucho { get; set; }
    }
}