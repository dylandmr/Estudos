using MatrixMax.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMax.DAO
{
    public class CategoriaDAO
    {
        public void Adiciona(Categoria categoria)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Categorias.Add(categoria);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Categoria categoria)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Entry(categoria).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Categoria> ListaCategorias()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Categorias.Where(c => c.CategoriaId == null).ToList();
            }
        }

        public IList<Categoria> ListaSubcategorias(int categoriaId)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Categorias.Where(c => c.CategoriaId == categoriaId).ToList();
            }
        }

        public Categoria BuscaPorId(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Categorias.Find(id);
            }
        }
    }
}
