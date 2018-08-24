using MatrixMax.Models;
using ModelagemInicial.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index(char C)
        {
            switch (C)
            {
                default:
                    var listaDeProdutos = new ProdutoDAO().Lista();
                    ViewBag.Title = "Produtos - Todos";
                    ViewBag.Categoria = "Todos";
                    return View(listaDeProdutos);
                case 'P':
                    listaDeProdutos = new ProdutoDAO().ListaPerifericos();
                    ViewBag.Title = "Produtos - Periféricos";
                    ViewBag.Categoria = "Periféricos";
                    return View(listaDeProdutos);
                case 'T':
                    listaDeProdutos = new ProdutoDAO().ListaToners();
                    ViewBag.Title = "Produtos - Toners";
                    ViewBag.Categoria = "Toners";
                    return View(listaDeProdutos);
                case ('C'):
                    listaDeProdutos = new ProdutoDAO().ListaCartuchos();
                    ViewBag.Title = "Produtos - Cartuchos";
                    ViewBag.Categoria = "Cartuchos";
                    return View(listaDeProdutos);
            }
            
            
        }
    }
}