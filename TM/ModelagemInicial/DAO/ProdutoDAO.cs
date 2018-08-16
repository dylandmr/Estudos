using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemInicial.DAO
{
    public class ProdutoDAO
    {
        public void Adiciona(Produto produto)
        {
            using (var contexto = new TMContext())
            {
                contexto.Produtos.Add(produto);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Produto produto)
        {
            using (var contexto = new TMContext())
            {
                contexto.Entry(produto).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Produto> ListaCartuchos()
        {
            using (var contexto = new TMContext())
            {
                return contexto.Produtos.Include(p => p.Marca).Include(p => p.Subcategoria).Where(p => p.TipoProduto == 'C').ToList();
            }
        }

        public IList<Produto> ListaToners()
        {
            using (var contexto = new TMContext())
            {
                return contexto.Produtos.Include(p => p.Marca).Include(p => p.Subcategoria).Where(p => p.TipoProduto == 'T').ToList();
            }
        }

        public IList<Produto> ListaPerifericos()
        {
            using (var contexto = new TMContext())
            {
                return contexto.Produtos.Include(p => p.Marca).Include(p => p.Subcategoria).Where(p => p.TipoProduto == 'P').ToList();
            }
        }

        public Produto BuscaPorId(int id)
        {
            using (var contexto = new TMContext())
            {
                return contexto.Produtos.Include(p => p.Marca).Include(p => p.Subcategoria).SingleOrDefault(p => p.Id == id);
            }
        }
    }
}
