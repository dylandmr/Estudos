using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemInicial
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new TMContext())
            {
                var dylan = contexto.Usuarios.First();

                var imagem = byteArrayToImage(dylan.ImagemDePerfil);

                byte[] senha = System.Text.Encoding.ASCII.GetBytes("admin");
                senha = new System.Security.Cryptography.SHA256Managed().ComputeHash(senha);
                
                Console.WriteLine(System.Text.Encoding.ASCII.GetString(senha) == System.Text.Encoding.ASCII.GetString(dylan.Senha) ? "Deu bom" : "Deu ruim");
                Console.ReadKey();
            }
        }

        private static void AdicionaUsuarioComImagemESenha(TMContext contexto)
        {
            byte[] senha = System.Text.Encoding.ASCII.GetBytes("admin");
            senha = new System.Security.Cryptography.SHA256Managed().ComputeHash(senha);

            var imagemPerfil = Image.FromFile("C:/Users/dylan/Desktop/estudos/TM/ModelagemInicial/Imagens/imagemperfil.png");

            var usuario_dylan = new Usuario()
            {
                Login = "admin",
                TipoUsuario = 'A',
                Pessoa = contexto.Pessoas.First(),
                Senha = senha,
                ImagemDePerfil = imageToByteArray(imagemPerfil),
            };

            contexto.Usuarios.Add(usuario_dylan);

            contexto.SaveChanges();

            ImprimeChangeTracker(contexto.ChangeTracker.Entries());
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private static void ImprimeChangeTracker(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("------------------------");
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
            Console.WriteLine("------------------------");
        }
    }
}
