using MatrixMax.DAO;
using MatrixMax.Models;
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

        public JsonResult Cadastra(List<ProdutosDaVenda> produtosDaVenda, Venda venda)
        {
            try
            {
                var usuario = (Usuario)Session["usuarioLogado"];
                venda.UsuarioId = usuario.Id;

                var formaDAO = new FormaDePagamentoDAO();
                var formaDePagamentoSelecionada = new FormaDePagamentoDAO().BuscaPorId((int)venda.FormaDePagamentoId);

                if (venda.Parcelas > 0)
                {
                    var cartao = formaDAO.BuscaPorId(3);
                    venda.Previsao = venda.Data.AddDays(cartao.Previsao * venda.Parcelas);
                }
                else
                {
                    venda.Previsao = venda.Data.AddDays(formaDePagamentoSelecionada.Previsao);
                }

                venda.Produtos = produtosDaVenda;
                new VendaDAO().Adiciona(venda);
                new ProdutoDAO().DecrementaEstoqueDos(produtosDaVenda);
                return Json(new { adicionou = true });
            }
            catch (Exception e)
            {
                return Json(new { adicionou = false, msg = e.Message });
            }
        }
    }
}