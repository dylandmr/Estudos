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

        public double TotalBrutoHoje()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Vendas.Where(v => v.Data == DateTime.Today).ToList().Sum(v => v.ProcessaDesconto().ValorTotal);
            }
        }

        public int TotalVendasHoje()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Vendas.Where(v => v.Data == DateTime.Today).ToList().Count;
            }
        }

        public int TotalProdutosVendidosHoje()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Vendas.Include(v => v.Produtos).Where(v => v.Data == DateTime.Today).ToList().Sum(v => v.Produtos.Sum(pv => pv.Quantidade));
            }
        }

        public List<int> VendasHojePorCategoria()
        {
            using (var contexto = new MatrixMaxContext())
            {
                var lista = new List<int>();
                var vendas = contexto.Vendas.Where(v => v.Data == DateTime.Today).ToList();
                lista.Add(vendas.Where(v => v.FormaDePagamentoId == 1).Count());
                lista.Add(vendas.Where(v => v.FormaDePagamentoId == 2).Count());
                lista.Add(vendas.Where(v => v.FormaDePagamento.BandeiraCartao).Count());
                lista.Add(vendas.Where(v => v.FormaDePagamentoId == 5).Count());
                return lista;
            }
        }
    }
}
