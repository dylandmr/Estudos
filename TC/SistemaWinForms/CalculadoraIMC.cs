using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWinForms
{
    interface ICalculadoraObserver
    {
        void ResultadoIMC(double imc);
    }

    class CalculadoraIMC
    {
        private IList<ICalculadoraObserver> observadores =
            new List<ICalculadoraObserver>();

        public void AdicionaObservador(ICalculadoraObserver observer)
        {
            observadores.Add(observer);
        }

        public void RemoveObservador(ICalculadoraObserver observer)
        {
            observadores.Remove(observer);
        }

        public void CalculaIMC(double altura, double peso)
        {
            if (altura == 0 || peso == 0)
                throw new ArgumentException("Peso ou altura inválidos!");

            double imc = peso / (Math.Pow(altura, 2));

            foreach (var observador in observadores)
            {
                observador.ResultadoIMC(imc);
            }
        }
    }
}
