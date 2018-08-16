using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemInicial.DAO
{
    public interface IDAO
    {
        void Adiciona(object objeto);
        IList<object> Lista();
        object BuscaPorId(int id);
        void Atualiza(object objeto);
    }
}
