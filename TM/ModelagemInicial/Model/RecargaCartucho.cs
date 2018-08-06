using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class RecargaCartucho
    {
        public Recarga Recarga { get; set; }
        public Cartucho Cartucho { get; set; }
        public int RecargaId { get; set; }
        public int CartuchoId { get; set; }
        public double Valor { get; set; }
    }
}