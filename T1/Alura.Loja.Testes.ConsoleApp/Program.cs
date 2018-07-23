using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto banana = new Produto()
            {
                Nome = "Banana",
                PrecoUnitario = 2.7,
                Categoria = "Frutas",
                Unidade = "Unidade"
            };

            Compra compra = new Compra();
            compra.Quantidade = 5;
            compra.Produto = banana;
            compra.Preco = compra.Quantidade * banana.PrecoUnitario;

            
        }        
    }
}