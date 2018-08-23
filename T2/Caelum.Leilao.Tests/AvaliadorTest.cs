using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    public class AvaliadorTest
    {
        [Test]
        public void DeveEntenderLancesCrescentes()
        {
            //1-CENÁRIO:
            var joao = new Usuario("João");
            var maria = new Usuario("Maria");
            var pedro = new Usuario("Pedro");

            var leilao = new Leilao("Galaxy S9+");

            leilao.Propoe(new Lance(joao, 200));
            leilao.Propoe(new Lance(pedro, 300));
            leilao.Propoe(new Lance(maria, 500));

            //2-AÇÃO:
            var avaliador = new Avaliador();
            avaliador.Avalia(leilao);

            //3-VALIDAÇÃO:
            Assert.AreEqual(200, avaliador.MenorLance, 0.00001);
            Assert.AreEqual(500, avaliador.MaiorLance, 0.00001);
        }

        [Test]
        public void TestaCalculoDeMediaDosLances()
        {
            var joao = new Usuario("João");

            var leilao = new Leilao("Ipad Air");

            leilao.Propoe(new Lance(joao, 897));
            leilao.Propoe(new Lance(joao, 2039));
            leilao.Propoe(new Lance(joao, 183));

            var avaliador = new Avaliador();
            avaliador.Avalia(leilao);

            Assert.AreEqual(1039.666666667, avaliador.LanceMedio, 0.00001);
        }
    }
}
