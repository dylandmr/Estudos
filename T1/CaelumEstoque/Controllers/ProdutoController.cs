using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            var produtoDAO = new ProdutosDAO();
            //IList<Produto> produtos = produtoDAO.Lista(); <- Desnecessário!
            ViewBag.Produtos = produtoDAO.Lista();
            return View();
        }

        public ActionResult Form()
        {
            var categoriasDAO = new CategoriasDAO();
            ViewBag.Categorias = categoriasDAO.Lista();
            return View();
        }

        [HttpPost] // <- Anotação que informa que esse método só aceita form post.
        public ActionResult Adiciona(Produto produto)  // <- Model Binder transforma os parâmetros em objetos!
        {
            var produtosDAO = new ProdutosDAO();
            produtosDAO.Adiciona(produto);
            //return View();
            return RedirectToAction("Index", "Produto"); // <- Redirecionamento da action.
        }
    }
}