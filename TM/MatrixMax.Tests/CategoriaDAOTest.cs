using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMax.DAO
{
    [TestFixture]
    public class CategoriaDAOTest
    {
        [Test]
        public void DeveRetornarTodasAsCategorias()
        {
            var dao = new CategoriaDAO();
            var categorias = dao.ListaCategorias();

            Assert.IsTrue(categorias.Count > 0);
        }

        [Test]
        public void DeveRetornarTodasAsSubcategorias()
        {
            var dao = new CategoriaDAO();
            var subcategorias = dao.ListaTodasAsSubcategorias();
            
            Assert.IsTrue(subcategorias.Where(s => s.CategoriaId.HasValue).Count() > 0);
            Assert.AreEqual(0, subcategorias.Where(s => !s.CategoriaId.HasValue).Count());
        }

        [Test]
        public void DeveRetornarSubcategoriasDesativadas()
        {
            var dao = new CategoriaDAO();
            var subcategorias = dao.ListaTodasAsSubcategoriasDesativadas();

            Assert.AreEqual(0, subcategorias.Count);
        }

        [Test]
        public void DeveRetornarCategoriasDesativadas()
        {
            var dao = new CategoriaDAO();
            var categorias = dao.ListaCategoriasDesativadas();

            Assert.AreEqual(0, categorias.Count);
        }
    }
}
