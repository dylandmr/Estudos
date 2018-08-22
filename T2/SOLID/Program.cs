using SOLID.Single_Responsibility_Principle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            var desenvolvedor = new Funcionario(new Desenvolvedor(new DezOuVintePorcento()), 2000);
            Console.WriteLine($"Um desenvolvedor com sal�rio base de R${desenvolvedor.SalarioBase},00 receber� R${new CalculadoraDeSalario().Calcula(desenvolvedor)},00.");
            Console.ReadKey();
        }
    }
}