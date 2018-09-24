using MatrixMax.DAO;
using MatrixMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class MarcaController : Controller
    {
        public JsonResult getMarcas()
        {
            return Json(new
            {
                data = from m in new MarcaDAO().Lista()
                         select new { m.Nome, m.Id }
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Adiciona(Marca marca)
        {
            if (new Regex(@"^[A-ZÁÉÍÓÚÃÕ][A-záéíóúãõ]{1,}(\s[A-zÁÉÍÓÚÃÕáéíóúãõ]{2,})*$").IsMatch(marca.Nome))
            {
                new MarcaDAO().Adiciona(marca);
                return Json(new { adicionou = true });
            } else
            {
                return Json(new { adicionou = false, msg = "Nome inválido." });
            }
        }
    }
}