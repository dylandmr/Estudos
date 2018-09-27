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
            var dao = new PessoaDAO();
            if (dao.Existe(pessoa.CpfCnpj) != null)
            {
                return Json(new { adicionou = false, msg = "Já existe um cliente cadastrado com este CPF/CNPJ." });
            }
            else
            {
                if (pessoa.Valida() && pessoa.Endereco.Valida())
                {
                    dao.Adiciona(pessoa);
                    return Json(new { adicionou = true });
                } else
                {
                    return Json(new { adicionou = false, msg = "Dados inválidos." });
                }
            }
        }
    }
}