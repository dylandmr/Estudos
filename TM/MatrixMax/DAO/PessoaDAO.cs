using MatrixMax.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMax.DAO
{
    public class PessoaDAO
    {
        public void Adiciona(Pessoa pessoa)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Pessoas.Add(pessoa);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Pessoa pessoa)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Entry(pessoa).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Pessoa> Lista()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Pessoas.Include(p => p.Endereco).ToList();
            }
        }

        public Pessoa Existe(string cpfCnpj)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Pessoas.Where(p => p.CpfCnpj == cpfCnpj).FirstOrDefault();
            }
        }
    }
}
