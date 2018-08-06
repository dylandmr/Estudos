using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public class Funcionario : Usuario, IAtendente
    {

        public void CadastraCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void CadastraRecarga(Recarga recarga)
        {
            throw new NotImplementedException();
        }

        public void CadastraVenda(Venda venda)
        {
            throw new NotImplementedException();
        }
    }
}