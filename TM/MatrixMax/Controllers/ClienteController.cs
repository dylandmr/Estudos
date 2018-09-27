using MatrixMax.DAO;
using MatrixMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Clientes";
            return View();
        }

        public ActionResult Atualizar()
        {
            return View();
        }

        public JsonResult Adiciona(Pessoa pessoa)
        {
            new PessoaDAO().Adiciona(pessoa);
            return Json(new { adicionou = true });
        }
    }
}