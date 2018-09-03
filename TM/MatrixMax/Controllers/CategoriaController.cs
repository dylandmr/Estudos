using MatrixMax.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class CategoriaController : Controller
    {
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
    }
}