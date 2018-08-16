using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemInicial.DAO
{
    public class SubcategoriaDAO
    {
        public void Adiciona(Subcategoria subcategoria)
        {
            using (var contexto = new TMContext())
            {
                contexto.Subcategorias.Add(subcategoria);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Subcategoria subcategoria)
        {
            using (var contexto = new TMContext())
            {
                contexto.Entry(subcategoria).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Subcategoria> Lista()
        {
            using (var contexto = new TMContext())
            {
                return contexto.Subcategorias.ToList();
            }
        }
    }
}
