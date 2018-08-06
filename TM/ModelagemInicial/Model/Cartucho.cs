using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class Cartucho : Produto
    {
        public string Modelo { get; set; }
        public IList<RecargaCartucho> Recargas { get; set; }
        public MarcaCartuchoToner MarcaCartuchoToner { get; set; }
        public IList<TiposCartucho> Tipos { get; set; }

        public Cartucho()
        {
            Recargas = new List<RecargaCartucho>();
            Tipos = new List<TiposCartucho>();
        }

        public void IncluiTipo(TipoCartuchoToner tipo, double preco)
        {
            Tipos.Add(new TiposCartucho() { TipoCartuchoToner = tipo, Preco = preco });
        }
    }
}