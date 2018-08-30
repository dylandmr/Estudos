using MatrixMax.DAO;
using MatrixMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index(char C)
        {
            switch (C)
            {
                default:
                    var listaDeProdutos = new ProdutoDAO().Lista();
                    ViewBag.Title = "Produtos - Todos";
                    ViewBag.Categoria = "Todos";
                    return View(listaDeProdutos);
                case 'P':
                    listaDeProdutos = new ProdutoDAO().ListaPerifericos();
                    ViewBag.Title = "Produtos - Periféricos";
                    ViewBag.Categoria = "Periféricos";
                    return View(listaDeProdutos);
                case 'T':
                    listaDeProdutos = new ProdutoDAO().ListaToners();
                    ViewBag.Title = "Produtos - Toners";
                    ViewBag.Categoria = "Toners";
                    return View(listaDeProdutos);
                case ('C'):
                    listaDeProdutos = new ProdutoDAO().ListaCartuchos();
                    ViewBag.Title = "Produtos - Cartuchos";
                    ViewBag.Categoria = "Cartuchos";
                    return View(listaDeProdutos);
            }
        }

        public JsonResult getCategorias()
        {
            return Json(new
            {
                Categorias = from c in new CategoriaDAO().ListaCategorias()
                            select new { c.Nome, c.Id }
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getSubcategorias(int id)
        {
            return Json(new
            {
                Subcategorias = from c in new CategoriaDAO().ListaSubcategorias(id)
                             select new { c.Nome, c.Id }
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getMarcas()
        {
            return Json(new
            {
                Marcas = from m in new MarcaDAO().Lista()
                                select new { m.Nome, m.Id }
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            new ProdutoDAO().Adiciona(produto);
            return RedirectToAction("Index", new { C = "G" });
        }
    }
}