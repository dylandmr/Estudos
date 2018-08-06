using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class TiposCartucho
    {
        public Cartucho Cartucho { get; set; }
        public TipoCartuchoToner TipoCartuchoToner { get; set; }
        public int CartuchoId { get; set; }
        public int TipoCartuchoTonerId { get; set; }
        public double Preco { get; set; }
    }
}