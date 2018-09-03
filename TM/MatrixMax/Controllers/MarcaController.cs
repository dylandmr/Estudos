using MatrixMax.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Marcas = from m in new MarcaDAO().Lista()
                         select new { m.Nome, m.Id }
            }, JsonRequestBehavior.AllowGet);
        }
    }
}