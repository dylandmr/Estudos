using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public abstract class Produto
    {
        public int Id
        {
            get => default(int);
            set
            {
            }
        }

        public double Preco
        {
            get => default(int);
            set
            {
            }
        }

        public int Estoque
        {
            get => default(int);
            set
            {
            }
        }

        public Categoria Categoria
        {
            get => default(Categoria);
            set
            {
            }
        }

        public IList<Venda> Vendas
        {
            get => default(Venda);
            set
            {
            }
        }
    }
}