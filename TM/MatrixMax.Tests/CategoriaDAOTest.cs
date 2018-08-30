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
        public void DeveRetornarCategorias()
        {
            var dao = new CategoriaDAO();
            var categorias = dao.ListaCategorias();

            var devesertrue = categorias.Where(c => c.Nome == "Cartuchos").ToList().Count == 1;
            var deveserfalse = categorias.Where(c => c.Nome == "Compatíveis").ToList().Count >= 1;

            Assert.IsTrue(devesertrue);
            Assert.IsFalse(deveserfalse);
        }

        [Test]
        public void DeveRetornarSubcategoriasCartucho()
        {
            var dao = new CategoriaDAO();
            var subcategorias = dao.ListaSubcategorias(2);

            var devesertrue = subcategorias.Where(c => c.Nome == "Compatíveis").ToList().Count == 1;

            Assert.IsTrue(devesertrue);
            Assert.AreEqual(3, subcategorias.Count);
        }
    }
}
