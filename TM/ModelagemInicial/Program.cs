using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemInicial
{
    class Program
    {
        static void Main(string[] args)
        {
            var atendente = new Funcionario()
            {
                Cpf = "096.387.469-12",
                Email = "dylandmrodrigues@hotmail.com",
                Nome = "Dylan Rodrigues",
                Senha = "Senha123",
                ImagemPerfil = "hash"
            };

            var mouse = new Periferico()
            {
                Estoque = 20,
                Preco = 40.5,
                Nome = "Mouse Strong",
                CategoriaPeriferico = new CategoriaPeriferico() { Nome = "Mouse" },
                Categoria = new Categoria() { Nome = "Periférico" },
            };

            var cliente = new PessoaFisica()
            {
                Nome = "Joãozinho",
                Cpf = "1234",
                Endereco = new Endereco() { Cep = 89030000, Bairro = "Itoupava Seca", Numero = 3090, Rua = "São Paulo" },
            };

            var venda = new Venda()
            {
                Cliente = cliente,
                Data = DateTime.Now,
                Funcionario = atendente,
            };

            venda.IncluiProduto(mouse);

            using (var contexto = new TMContext())
            {
                contexto.Usuarios.Add(atendente);
                contexto.Produtos.Add(mouse);
                contexto.Clientes.Add(cliente);
                contexto.Vendas.Add(venda);

                ImprimeChangeTracker(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();

                ImprimeChangeTracker(contexto.ChangeTracker.Entries());
            }
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
