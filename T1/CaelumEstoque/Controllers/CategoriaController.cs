using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        [Route("produtos/categorias", Name = "ListaCategoria")]
        public ActionResult Index()
        {
            var categoriaDAO = new CategoriasDAO();
            var categorias = categoriaDAO.Lista();
            ViewBag.Categorias = categorias;
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        [Route("produtos/categorias/adiciona", Name = "AdicionaCategoria")]
        [HttpPost]
        public ActionResult Adiciona(CategoriaDoProduto categoria)
        {
            var categoriasDAO = new CategoriasDAO();
            categoriasDAO.Adiciona(categoria);
            return RedirectToAction("Index");
        }
    }
}