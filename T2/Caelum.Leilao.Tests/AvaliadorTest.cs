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
            var maria = new Usuario("Maria");

            var leilao = new Leilao("Ipad Air");

            leilao.Propoe(new Lance(joao, 897));
            leilao.Propoe(new Lance(maria, 2039));
            leilao.Propoe(new Lance(joao, 183));

            var avaliador = new Avaliador();
            avaliador.Avalia(leilao);

            Assert.AreEqual(1039.666666667, avaliador.LanceMedio, 0.00001);
        }

        [Test]
        public void TestaLeilaoComUmLance()
        {
            var joao = new Usuario("João");
            var leilao = new Leilao("Galaxy S9+");

            leilao.Propoe(new Lance(joao, 200));
            
            var avaliador = new Avaliador();
            avaliador.Avalia(leilao);
            
            Assert.AreEqual(200, avaliador.MenorLance, 0.00001);
            Assert.AreEqual(200, avaliador.MaiorLance, 0.00001);
        }

        [Test]
        public void TestaLeilaoComLancesAleatorios()
        {
            var joao = new Usuario("João");
            var maria = new Usuario("Maria");

            var leilao = new Leilao("Galaxy S9+");

            leilao.Propoe(new Lance(joao, 200));
            leilao.Propoe(new Lance(maria, 450));
            leilao.Propoe(new Lance(joao, 120));
            leilao.Propoe(new Lance(maria, 700));
            leilao.Propoe(new Lance(joao, 630));
            leilao.Propoe(new Lance(maria, 230));
            
            var avaliador = new Avaliador();
            avaliador.Avalia(leilao);
            
            Assert.AreEqual(120, avaliador.MenorLance, 0.00001);
            Assert.AreEqual(700, avaliador.MaiorLance, 0.00001);
        }

        [Test]
        public void TestaLeilaoComLancesDecrescentes()
        {
            var joao = new Usuario("João");
            var maria = new Usuario("Maria");

            var leilao = new Leilao("Galaxy S9+");

            leilao.Propoe(new Lance(joao, 400));
            leilao.Propoe(new Lance(maria, 300));
            leilao.Propoe(new Lance(joao, 200));
            leilao.Propoe(new Lance(maria, 100));
            
            var avaliador = new Avaliador();
            avaliador.Avalia(leilao);
            
            Assert.AreEqual(100, avaliador.MenorLance, 0.00001);
            Assert.AreEqual(400, avaliador.MaiorLance, 0.00001);
        }

        [Test]
        public void TestaMaioresComQuatroLances()
        {
            var joao = new Usuario("João");
            var maria = new Usuario("Maria");

            var leilao = new Leilao("Galaxy S9+");

            leilao.Propoe(new Lance(joao, 400));
            leilao.Propoe(new Lance(maria, 200));
            leilao.Propoe(new Lance(joao, 300));
            leilao.Propoe(new Lance(maria, 100));

            var avaliador = new Avaliador();
            avaliador.Avalia(leilao);

            Assert.AreEqual(3, avaliador.TresMaiores.Count);
            Assert.AreEqual(400, avaliador.TresMaiores[0].Valor, 0.00001);
            Assert.AreEqual(300, avaliador.TresMaiores[1].Valor, 0.00001);
            Assert.AreEqual(200, avaliador.TresMaiores[2].Valor, 0.00001);
        }

        [Test]
        public void TestaMaioresComDoisLances()
        {
            var joao = new Usuario("João");
            var maria = new Usuario("Maria");

            var leilao = new Leilao("Galaxy S9+");

            leilao.Propoe(new Lance(joao, 400));
            leilao.Propoe(new Lance(maria, 200));

            var avaliador = new Avaliador();
            avaliador.Avalia(leilao);

            Assert.AreEqual(2, avaliador.TresMaiores.Count);
            Assert.AreEqual(400, avaliador.TresMaiores[0].Valor, 0.00001);
            Assert.AreEqual(200, avaliador.TresMaiores[1].Valor, 0.00001);
        }

        [Test]
        public void TestaMaioresSemNenhumLance()
        {
            var joao = new Usuario("João");
            var maria = new Usuario("Maria");

            var leilao = new Leilao("Galaxy S9+");

            var avaliador = new Avaliador();
            avaliador.Avalia(leilao);

            Assert.AreEqual(0, avaliador.TresMaiores.Count);
        }
    }
}
