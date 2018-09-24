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

        public ActionResult Estoque()
        {
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
        public JsonResult Adiciona(Produto produto)
        {
            if (produto.Valida())
            {
                new ProdutoDAO().Adiciona(produto);
                return Json(new { adicionou = true });
            }
            else return Json(new { adicionou = false, msg = "Dados inválidos informados." });
        }

        [HttpPost]
        public JsonResult Atualiza(Produto produtoedit)
        {
            if (produtoedit.Valida())
            {
                var dao = new ProdutoDAO();
                if (dao.Existe(produtoedit.Id) && !dao.ExisteIgual(produtoedit))
                {
                    dao.Atualiza(produtoedit);
                    return Json(new { atualizou = true });
                }
                else return Json(new { atualizou = false, msg = "Nenhuma alteração feita no produto." });
            }
            else return Json(new { atualizou = false, msg = "Dados inválidos informados." });
        }

        public JsonResult Desativa(int[] ids)
        {
            var dao = new ProdutoDAO();
            foreach (var id in ids)
                dao.Desativa(id);
            return Json(new { apagou = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Ativa(int[] ids)
        {
            var dao = new ProdutoDAO();
            foreach (var id in ids)
                dao.Ativa(id);
            return Json(new { ativou = true }, JsonRequestBehavior.AllowGet);
        }
    }
}