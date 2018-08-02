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
            ViewBag.Produto = new Produto();
            var categoriasDAO = new CategoriasDAO();
            ViewBag.Categorias = categoriasDAO.Lista();
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            var id_Informatica = 1;
            if (produto.CategoriaId.Equals(id_Informatica) && produto.Preco < 100)
                ModelState.AddModelError("produto.InformaticaPrecoInvalido", "Produtos de informática tem preço mínimo de R$100,00.");

            if (ModelState.IsValid)
            {
                var produtosDAO = new ProdutosDAO();
                produtosDAO.Adiciona(produto);
                return RedirectToAction("Index", "Produto");
            } else
            {
                var categoriasDAO = new CategoriasDAO();
                ViewBag.Categorias = categoriasDAO.Lista();
                ViewBag.Produto = produto;
                return View("Form");
            }
        }
    }
}