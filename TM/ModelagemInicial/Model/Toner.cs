using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class Toner : Produto
    {
        public string Modelo { get; set; }
        public MarcaCartuchoToner MarcaCartuchoToner { get; set; }
        public TipoCartuchoToner TipoCartuchoToner { get; set; }
    }
}