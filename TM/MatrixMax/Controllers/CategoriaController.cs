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
                data = from c in new CategoriaDAO().ListaCategorias()
                             select new { c.Nome, c.Id }
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getSubcategorias(int id)
        {
            return Json(new
            {
                data = from c in new CategoriaDAO().ListaSubcategorias(id)
                                select new { c.Nome, c.Id }
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getTodasAsSubcategorias()
        {
            return Json(new
            {
                data = from c in new CategoriaDAO().ListaTodasAsSubcategorias()
                       select new { c.Nome, c.Id, Categoria = c.CategoriaDaSubcategoria.Nome, c.CategoriaId}
            }, JsonRequestBehavior.AllowGet);
        }
    }
}