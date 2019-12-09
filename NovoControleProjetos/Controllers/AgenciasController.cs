using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class AgenciasController : Controller
    {
        DAL.Agencias_DAL agencia_DAL = new DAL.Agencias_DAL(); 
        // GET: Agencias
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _ListaAgencias(int? cod_agencia)
        {
            var agencias = agencia_DAL.ListaEsteira();
            ViewBag.agencias = agencias.OrderBy(x => x.nome_agencia);
            ViewBag.cod_agencia = cod_agencia;
            return PartialView(agencias);
        }
    }
}