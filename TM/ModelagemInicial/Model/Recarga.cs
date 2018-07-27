using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class Recarga
    {
        public int Id { get; set; }

        public DateTime DataEntrega { get; set; }

        public IList<Cartucho> Cartuchos { get; set; }

        public int Status { get; set; }

        public Cliente Cliente { get; set; }

        public Venda ConfirmaVenda(Recarga recarga)
        {
            throw new System.NotImplementedException();
        }
    }
}