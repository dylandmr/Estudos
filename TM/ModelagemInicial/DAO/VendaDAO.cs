﻿using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemInicial.DAO
{
    public class VendaDAO
    {
        public void Adiciona(Venda venda)
        {
            using (var contexto = new TMContext())
            {
                contexto.Vendas.Add(venda);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Venda venda)
        {
            using (var contexto = new TMContext())
            {
                contexto.Entry(venda).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Venda BuscaPorId(int id)
        {
            using (var contexto = new TMContext())
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

        public IList<Venda> ListaFInalizadas()
        {
            using (var contexto = new TMContext())
            {
                return contexto.Vendas
                    .Include(v => v.Produtos)
                    .ThenInclude(vp => vp.Produto)
                    .Include(v => v.FormaDePagamento)
                    .Include(v => v.Pessoa)
                    .Where(v => v.TipoStatusVenda == 0 || v.TipoStatusVenda == 7)
                    .ToList();
            }
        }

        public IList<Venda> ListaRecargas()
        {
            using (var contexto = new TMContext())
            {
                return contexto.Vendas
                    .Include(v => v.Produtos)
                    .ThenInclude(vp => vp.Produto)
                    .Include(v => v.FormaDePagamento)
                    .Include(v => v.Pessoa)
                    .Where(v => v.TipoStatusVenda > 0 && v.TipoStatusVenda < 7)
                    .ToList();
            }
        }
    }
}
