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
        public IList<RecargaCartucho> Cartuchos { get; set; }
        public int Status { get; set; }
        public Cliente Cliente { get; set; }
        public double ValorTotal { get; set; }

        public Venda ConfirmaVenda(Recarga recarga)
        {
            throw new System.NotImplementedException();
        }

        public Recarga()
        {
            Cartuchos = new List<RecargaCartucho>();
        }

        public void IncluiCartucho(Cartucho cartucho, double preco, int quantidade)
        {
            Cartuchos.Add(new RecargaCartucho() { Cartucho = cartucho });
            ValorTotal += preco * quantidade;
        }
    }
}