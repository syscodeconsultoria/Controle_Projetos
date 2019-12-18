using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{

    public class HomeController : Controller
    {

        //Instanciando classes de conexão com o banco de dados
        private DAL.Projeto_DAL Projeto_DAL = new DAL.Projeto_DAL();

        public ActionResult Index()
        {
            var projetos = Projeto_DAL.ListaProjetosParaCombo(5);

            var model = projetos.GroupBy(p => p.IdProjeto).Select(i => i.First());

            return View(model);
        }



        public ActionResult About()
        {

            return View();
        }


        public ActionResult OperacaoSucesso()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View("~Views/Shared/Error.cshtml");

        }

        #region Métodos

        #endregion
    }
}