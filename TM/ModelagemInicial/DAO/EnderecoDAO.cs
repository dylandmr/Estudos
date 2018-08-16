using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemInicial.DAO
{
    public class EnderecoDAO
    {
        public void Adiciona(Endereco endereco)
        {
            using (var contexto = new TMContext())
            {
                contexto.Enderecos.Add(endereco);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Endereco endereco)
        {
            using (var contexto = new TMContext())
            {
                contexto.Entry(endereco).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Endereco> Lista()
        {
            using (var contexto = new TMContext())
            {
                return contexto.Enderecos.ToList();
            }
        }
    }
}
