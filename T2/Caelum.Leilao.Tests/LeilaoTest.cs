using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class LeilaoTest
    {
        [Test]
        public void DeveReceberUmLance()
        {
            var leilao = new Leilao("Notebook Acer");
            Assert.AreEqual(0, leilao.Lances.Count);

            leilao.Propoe(new Lance(new Usuario("Bill Gates"), 5000));

            Assert.AreEqual(1, leilao.Lances.Count());
            Assert.AreEqual(5000, leilao.Lances[0].Valor, 0.0001);
        }

        [Test]
        public void DeveReceberVariosLances()
        {
            var leilao = new Leilao("Notebook Acer");
            
            leilao.Propoe(new Lance(new Usuario("Bill Gates"), 5000));
            leilao.Propoe(new Lance(new Usuario("Rita Lee"), 4000));

            Assert.AreEqual(2, leilao.Lances.Count());
            Assert.AreEqual(5000, leilao.Lances[0].Valor, 0.0001);
            Assert.AreEqual(4000, leilao.Lances[1].Valor, 0.0001);
        }

        [Test]
        public void NaoDeveAceitarLancesSeguidosDoMesmoUsuario()
        {
            var leilao = new Leilao("Notebook Dell");

            var michelTemer = new Usuario("Michel Temer");

            leilao.Propoe(new Lance(michelTemer, 1500));
            leilao.Propoe(new Lance(michelTemer, 4000));

            Assert.AreEqual(1, leilao.Lances.Count());
            Assert.AreEqual(1500, leilao.Lances[0].Valor, 0.0001);
        }

        [Test]
        public void NaoDeveAceitarMaisDeCincoLancesDoMesmoUsuario()
        {
            var leilao = new Leilao("Notebook Dell");

            var michelTemer = new Usuario("Michel Temer");
            var dilmaRoussef = new Usuario("Dulma Roussef");

            leilao.Propoe(new Lance(michelTemer, 100));
            leilao.Propoe(new Lance(dilmaRoussef, 200));
            leilao.Propoe(new Lance(michelTemer, 300));
            leilao.Propoe(new Lance(dilmaRoussef, 400));
            leilao.Propoe(new Lance(michelTemer, 500));
            leilao.Propoe(new Lance(dilmaRoussef, 600));
            leilao.Propoe(new Lance(michelTemer, 700));
            leilao.Propoe(new Lance(dilmaRoussef, 800));
            leilao.Propoe(new Lance(michelTemer, 900));
            leilao.Propoe(new Lance(dilmaRoussef, 1000));
            leilao.Propoe(new Lance(michelTemer, 1100));

            Assert.AreEqual(10, leilao.Lances.Count());

            var ultimoIndex = leilao.Lances.Count - 1;
            var ultimoLance = leilao.Lances[ultimoIndex];
            Assert.AreEqual(1000, ultimoLance.Valor, 0.00001);
        }
    }
}
