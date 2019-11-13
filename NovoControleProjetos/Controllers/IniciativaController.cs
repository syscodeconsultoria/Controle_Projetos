using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class IniciativaController : Controller
    {
        DAL.Iniciativa_DAL iniciativa_DAL = new DAL.Iniciativa_DAL();
        OrcamentoController orcamentoController = new OrcamentoController();
        RelacionamentosController relacionamentosController = new RelacionamentosController();

        // GET: Iniciativa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            var projeto = iniciativa_DAL.GetIniciativa(id);
            return View(projeto);
        }

        [HttpPost]
        public ActionResult Create(Iniciativa iniciativa, Orcamento orcamento)
        {        
            int idOrcamento = orcamentoController.InsereOrcamento(orcamento, iniciativa.Id_Iniciativa);

            iniciativa.cod_orcamento = idOrcamento;
            //relacionamentosController.RelacionamentoOrcamentoProjeto(iniciativa.Id_Iniciativa, idOrcamento);          
            
            iniciativa_DAL.UpdateIniciativa(iniciativa);
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult _InsertIniciativa()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult _InsertIniciativa(string nome)
        {
            var id = iniciativa_DAL.RetornaIdIniciativa(nome);
            return Json(id,JsonRequestBehavior.AllowGet);
        }

        public ActionResult _DetalhesIniciativa()
        {
            return PartialView();
        }
    }
}