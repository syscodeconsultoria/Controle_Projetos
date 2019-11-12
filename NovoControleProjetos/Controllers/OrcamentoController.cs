using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class OrcamentoController : Controller
    {
        DAL.Orcamento_DAL orcamento_DAL = new DAL.Orcamento_DAL();

        // GET: Orcamento
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int InsereOrcamento(Orcamento orcamento, int? id_iniciativa)
        {
            var idOrcamento = orcamento_DAL.InsereOrcamento(orcamento, id_iniciativa);
            return idOrcamento;
        }

        [HttpPost]
        public int _CriaOrcamento(Orcamento orcamento)
        {
            var idOrcamento = orcamento_DAL.InsereOrcamentoRetornaId(orcamento);
            return idOrcamento;
        }

        public ActionResult _Create()
        {
            return PartialView();
        }

        public ActionResult _Details(int cod_orcamento)
        {
            return PartialView();
        }

        public ActionResult _Edit(int cod_orcamento)
        {
            return PartialView();
        }

        

    }
}