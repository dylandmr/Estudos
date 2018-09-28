using MatrixMax.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class VendaController : Controller
    {
        public ActionResult Index()
        {
            var formaPagamentoDAO = new FormaDePagamentoDAO();
            var categoriaDAO = new CategoriaDAO();
            ViewBag.FormasDePagamento = formaPagamentoDAO.ListaFormasDePagamento();
            ViewBag.Bandeiras = formaPagamentoDAO.ListaBandeiras();
            ViewBag.Produtos = new ProdutoDAO().Lista();
            ViewBag.Categorias = categoriaDAO.ListaCategoriasAtivas();
            ViewBag.Subcategorias = categoriaDAO.ListaTodasAsSubcategoriasAtivas();
            ViewBag.Title = "Vendas";
            return View();
        }

        public ActionResult Historico()
        {
            return View();
        }
    }
}