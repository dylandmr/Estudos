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

        public JsonResult getDesativados()
        {
            return Json(new
            {
                data = new ProdutoDAO().ListaDesativados()
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

        public JsonResult Ativa(int id)
        {
            new ProdutoDAO().Ativa(id);
            return Json(new { ativou = true }, JsonRequestBehavior.AllowGet);
        }
    }
}