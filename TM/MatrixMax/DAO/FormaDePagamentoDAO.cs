using MatrixMax.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemInicial.DAO
{
    public class FormaDePagamentoDAO
    {
        public void Adiciona(FormaDePagamento formaDePagamento)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.FormasDePagamento.Add(formaDePagamento);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(FormaDePagamento formaDePagamento)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Entry(formaDePagamento).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<FormaDePagamento> Lista()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.FormasDePagamento.ToList();
            }
        }
    }
}
