using MatrixMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var usuario = (Usuario)Session["usuarioLogado"];
            ViewBag.Title = "Dashboard";
            return View(usuario);
        }
    }
}