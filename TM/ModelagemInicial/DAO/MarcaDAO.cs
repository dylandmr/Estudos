using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemInicial.DAO
{
    public class MarcaDAO
    {
        public void Adiciona(Marca marca)
        {
            using (var contexto = new TMContext())
            {
                contexto.Marcas.Add(marca);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Marca marca)
        {
            using (var contexto = new TMContext())
            {
                contexto.Entry(marca).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Marca> Lista()
        {
            using (var contexto = new TMContext())
            {
                return contexto.Marcas.ToList();
            }
        }
    }
}
