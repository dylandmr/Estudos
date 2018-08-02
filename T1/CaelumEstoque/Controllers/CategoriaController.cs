using CaelumEstoque.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            var categoriaDAO = new CategoriasDAO();
            var categorias = categoriaDAO.Lista();
            ViewBag.Categorias = categorias;
            return View();
        }
    }
}