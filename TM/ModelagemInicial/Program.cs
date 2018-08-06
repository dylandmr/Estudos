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
            var original = new TipoCartuchoToner() { Tipo = "Original" };
            var remanu = new TipoCartuchoToner() { Tipo = "Remanufaturado - Troca" };
            var comp = new TipoCartuchoToner() { Tipo = "Compatível" };
            var tipo_recarga = new TipoCartuchoToner() { Tipo = "Recarga" };

            var cat_mouse = new CategoriaPeriferico() { Nome = "Mouse" };
            var cat_fone = new CategoriaPeriferico() { Nome = "Fone de Ouvido" };
            var cat_pendrive = new CategoriaPeriferico() { Nome = "Pendrive" };

            var multilaser = new MarcaPeriferico() { Nome = "Multilaser" };
            var c3tech = new MarcaPeriferico() { Nome = "C3Tech" };
            var logitech = new MarcaPeriferico() { Nome = "Logitech" };
            var kingston = new MarcaPeriferico() { Nome = "Kingston" };

            var hp = new MarcaCartuchoToner() { Nome = "HP" };

            var dinheiro = new FormaDePagamento() { Nome = "Dinheiro" };
            var visa = new FormaDePagamento() { Nome = "Visa" };
            var hipercard = new FormaDePagamento() { Nome = "Hipercard" };
            var mastercard = new FormaDePagamento() { Nome = "Mastercard" };

            var mouse = new Periferico()
            {
                Estoque = 20,
                Preco = 40.5,
                Nome = "Mouse Strong",
                CategoriaPeriferico = cat_mouse,
                MarcaPeriferico = multilaser
            };

            var fonepulse = new Periferico()
            {
                Estoque = 5,
                Preco = 59.0,
                Nome = "Fone Pulse",
                CategoriaPeriferico = cat_fone,
                MarcaPeriferico = multilaser
            };

            var pendrive = new Periferico()
            {
                Estoque = 10,
                Preco = 40,
                Nome = "Pen Drive 8gb",
                CategoriaPeriferico = cat_pendrive,
                MarcaPeriferico = kingston
            };

            var hp21 = new Cartucho()
            {
                Modelo = "HP21",
                Estoque = 2,
                MarcaCartuchoToner = hp
            };

            hp21.IncluiTipo(original, 129.0);
            hp21.IncluiTipo(remanu, 35.0);
            hp21.IncluiTipo(comp, 45.0);
            hp21.IncluiTipo(tipo_recarga, 27.0);

            var hp2612 = new Toner()
            {
                Modelo = "HP2612",
                MarcaCartuchoToner = hp,
                Estoque = 2,
                TipoCartuchoToner = remanu
            };

            var atendente = new Funcionario()
            {
                Cpf = "096.387.469-12",
                Email = "dylandmrodrigues@hotmail.com",
                Nome = "Dylan Rodrigues",
                Senha = "Senha123",
                ImagemPerfil = "hash"
            };

            var cliente = new PessoaFisica()
            {
                Nome = "Joãozinho",
                Cpf = "1234",
                Telefone = "98853-1864"
            };

            var loja = new PessoaJuridica()
            {
                Endereco = new Endereco() { Cep = 89030000, Bairro = "Itoupava Seca", Numero = 3090, Rua = "São Paulo" },
                Cnpj = "123.456.888.0001-01",
                Telefone = "3037-3790",
                RazaoSocial = "MatrixMax"
            };

            var venda = new Venda()
            {
                Cliente = cliente,
                Data = DateTime.Now,
                Funcionario = atendente,
                FormaDePagamento = dinheiro,
                Previsao = DateTime.Now,
            };

            venda.IncluiProduto(mouse, 2);
            venda.IncluiProduto(pendrive, 1);

            var vendatoner = new Venda()
            {
                Cliente = cliente,
                Data = DateTime.Now,
                Funcionario = atendente,
                FormaDePagamento = visa,
                Parcelas = 3,
                Previsao = DateTime.Now.AddMonths(1)
            };

            vendatoner.IncluiProduto(hp2612, 1);

            var vendacartucho = new Venda()
            {
                Cliente = cliente,
                Data = DateTime.Now,
                Funcionario = atendente,
                FormaDePagamento = mastercard,
                Parcelas = 1,
                Previsao = DateTime.Now
            };

            var tipo = hp21.Tipos.Where(t => t.TipoCartuchoToner == remanu).First();

            vendacartucho.IncluiCartucho(hp21, tipo.Preco, 1);

            var recarga = new Recarga()
            {
                Cliente = cliente,
                DataEntrega = DateTime.Now.AddDays(2),
                Status = 1
            };

            var hp21_recarga = hp21.Tipos.Where(t => t.TipoCartuchoToner == tipo_recarga).First();

            recarga.IncluiCartucho(hp21, hp21_recarga.Preco, 1);

            using (var contexto = new TMContext())
            {
                contexto.Usuarios.Add(atendente);

                contexto.Clientes.Add(cliente);
                contexto.Clientes.Add(loja);

                contexto.Produtos.Add(fonepulse);
                contexto.Produtos.Add(pendrive);
                contexto.Produtos.Add(mouse);
                contexto.Produtos.Add(hp21);
                contexto.Produtos.Add(hp2612);

                contexto.Vendas.Add(venda);
                contexto.Vendas.Add(vendatoner);
                contexto.Vendas.Add(vendacartucho);

                contexto.Recargas.Add(recarga);

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
