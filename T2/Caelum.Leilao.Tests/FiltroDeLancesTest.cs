﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class FiltroDeLancesTest
    {
        [Test]
        public void DeveSelecionarLancesEntre1000E3000()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
            new Lance(joao,2000),
            new Lance(joao,1000),
            new Lance(joao,3000),
            new Lance(joao, 800)});

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(2000, resultado[0].Valor, 0.00001);
        }

        [Test]
        public void DeveSelecionarLancesEntre500E700()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
            new Lance(joao,600),
            new Lance(joao,500),
            new Lance(joao,700),
            new Lance(joao, 800)});

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(600, resultado[0].Valor, 0.00001);
        }

        [Test]
        public void DeveSelecionarLancesMaioresQue5000()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
            new Lance(joao, 900),
            new Lance(joao, 5001),
            new Lance(joao, 800)});

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(5001, resultado[0].Valor, 0.00001);
        }

        [Test]
        public void DeveIgnorarMenoresQue500()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
            new Lance(joao, 235),
            new Lance(joao, 409),
            new Lance(joao, 399)});

            Assert.AreEqual(0, resultado.Count);
        }

        [Test]
        public void DeveIgnorarEntre3000E5000()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
            new Lance(joao, 3500),
            new Lance(joao, 4000),
            new Lance(joao, 4999)});

            Assert.AreEqual(0, resultado.Count);
        }
    }
}
