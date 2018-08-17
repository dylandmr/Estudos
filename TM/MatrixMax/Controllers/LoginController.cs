using MatrixMax.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autentica(string login, string senha)
        {
            var usuario = new UsuarioDAO().Autentica(login, senha);
            if (usuario != null)
            { 
                Session["usuarioLogado"] = usuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CredenciaisIncorretas", "Login e/ou senha inválido(s)!");
                return View("Index");
            }
        }
    }
}