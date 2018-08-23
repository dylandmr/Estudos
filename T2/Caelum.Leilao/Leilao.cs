using System.Collections.Generic;
namespace Caelum.Leilao
{
    public class Leilao
    {
        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            Descricao = descricao;
            Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            bool primeiroLance = Lances.Count == 0;

            if (primeiroLance || podeFazerLance(lance.Usuario))
            {
                Lances.Add(lance);
            }
        }

        private bool podeFazerLance(Usuario usuario)
        {
            return (!usuario.Equals(UltimoLance().Usuario) && quantLances(usuario) < 5);
        }
        private int quantLances(Usuario usuario)
        {
            int total = 0;
            foreach (var lanceunico in Lances)
            {
                if (lanceunico.Usuario.Equals(usuario)) total++;
            }

            return total;
        }

        private Lance UltimoLance()
        {
            return Lances[Lances.Count - 1];
        }
    }
}