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
        public ActionResult Index()
        {
            ViewBag.Title = "Produtos";
            return View();
        }

        public JsonResult getProduto(int id)
        {
            return Json(new ProdutoDAO().BuscaPorId(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getProdutos()
        {
            return Json(new
            {
                data = new ProdutoDAO().Lista()
            }, JsonRequestBehavior.AllowGet);
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
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Atualiza(Produto produto)
        {
            new ProdutoDAO().Atualiza(produto);
            return RedirectToAction("Index");
        }

        public JsonResult Desativa(int id)
        {
            new ProdutoDAO().Desativa(id);
            return Json(new { apagou = true }, JsonRequestBehavior.AllowGet);
        }
    }
}