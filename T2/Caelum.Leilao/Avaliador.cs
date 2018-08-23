using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double menorLance = Double.MaxValue;
        private double maiorLance = Double.MinValue;
        private double lanceMedio;

        public void Avalia(Leilao leilao)
        {
            foreach (var lance in leilao.Lances)
            {
                if (lance.Valor > maiorLance) maiorLance = lance.Valor;
                if (lance.Valor < menorLance) menorLance = lance.Valor;
            }
        }

        public void CalculaMedia(Leilao leilao)
        {
            double soma = 0;
            foreach (var lance in leilao.Lances)
            {
                soma += lance.Valor;
            }
            lanceMedio = soma / leilao.Lances.Count;
        }

        public double MaiorLance { get { return maiorLance; } }
        public double MenorLance { get { return menorLance; } }
        public double LanceMedio { get { return lanceMedio; } }
    }
}
