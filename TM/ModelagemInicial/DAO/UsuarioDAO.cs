using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemInicial.DAO
{
    public class UsuarioDAO
    {
        public void Adiciona(Usuario usuario)
        {
            using (var context = new TMContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        }

        public void Atualiza(Usuario usuario)
        {
            using (var contexto = new TMContext())
            {
                contexto.Entry(usuario).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Usuario Autentica(string login, string senha)
        {
            using (var contexto = new TMContext())
            {
                byte[] senhaHash = Encoding.ASCII.GetBytes(senha);
                senhaHash = new SHA256Managed().ComputeHash(senhaHash);
                return contexto.Usuarios.Include(u => u.Pessoa).FirstOrDefault(u => u.Login == login && u.Senha == senhaHash);
            } 
        }

        public IList<Usuario> Lista()
        {
            using (var contexto = new TMContext())
            {
                return contexto.Usuarios.Include(u => u.Pessoa).ToList();
            }
        }
    }
}
