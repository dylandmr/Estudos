﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemInicial.DAO
{
    public class PessoaDAO
    {
        public void Adiciona(Pessoa pessoa)
        {
            using (var contexto = new TMContext())
            {
                contexto.Pessoas.Add(pessoa);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Pessoa pessoa)
        {
            using (var contexto = new TMContext())
            {
                contexto.Entry(pessoa).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Pessoa> Lista()
        {
            using (var contexto = new TMContext())
            {
                return contexto.Pessoas.Include(p => p.Endereco).ToList();
            }
        }
    }
}
