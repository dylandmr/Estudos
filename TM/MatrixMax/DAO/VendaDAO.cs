using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixMax.Models;

namespace MatrixMax.DAO
{
    public class VendaDAO
    {
        public void Adiciona(Venda venda)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Vendas.Add(venda);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Venda venda)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Entry(venda).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Venda BuscaPorId(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Vendas
                    .Include(v => v.Produtos)
                    .ThenInclude(vp => vp.Produto)
                    .Include(v => v.FormaDePagamento)
                    .Include(v => v.Pessoa)
                    .Where(v => v.Id == id)
                    .SingleOrDefault();
            }
        }

        public IList<Venda> BuscaPorCliente(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Vendas
                    .Include(v => v.Produtos)
                    .Where(v => v.PessoaId == id)
                    .ToList();
            }
        }

        public IList<Venda> Lista()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Vendas
                    .Include(v => v.FormaDePagamento)
                    .Include(v => v.Pessoa)
                    .Include(v => v.Usuario)
                    .OrderByDescending(v => v.Data)
                    .ToList();
            }
        }

        public IList<ProdutosDaVenda> ListaProdutos(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Vendas
                    .Include(v => v.Produtos)
                    .ThenInclude(vp => vp.Produto)
                    .Where(v => v.Id == id)
                    .SingleOrDefault().Produtos; 
            }
        }
    }
}
