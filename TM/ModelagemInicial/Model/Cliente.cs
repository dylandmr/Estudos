using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public abstract class Cliente
    {
        public int Id { get; set; }

        public Endereco Endereco
        {
            get => default(Endereco);
            set
            {
            }
        }
    }
}