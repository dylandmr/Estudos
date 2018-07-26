﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public interface IAtendente
    {
        void CadastraCliente(Cliente cliente);
        void CadastraCategoria(Categoria Categoria);
        void CadastraVenda(Venda venda);
        void CadastraRecarga(Recarga recarga);
    }
}