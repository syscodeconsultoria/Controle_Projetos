using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class JornadaController : Controller
    {
        DAL.Jornada_DAL jornada_DAL = new DAL.Jornada_DAL();

        public int InsereJornada(Jornada jornada, int? id_iniciativa)
        {
            var idJornada = jornada_DAL.InsereJornadaRetornaId(jornada, id_iniciativa);
            return idJornada;
        }

        //[HttpPost]
        //public int _CriaOrcamento(Orcamento orcamento)
        //{
        //    var idOrcamento = orcamento_DAL.InsereOrcamentoRetornaId(orcamento);
        //    return idOrcamento;
        //}


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Create()
        {
            return PartialView();
        }

        public ActionResult _Details(int cod_jornada)
        {
            return PartialView();
        }

        public ActionResult _Edit(int cod_jornada)
        {
            return PartialView();
        }
    }
}