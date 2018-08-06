using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class TipoCartuchoToner
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public IList<TiposCartucho> Cartuchos { get; set; }

        public TipoCartuchoToner()
        {
            Cartuchos = new List<TiposCartucho>();
        }
    }
}