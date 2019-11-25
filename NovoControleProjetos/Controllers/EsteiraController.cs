using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class EsteiraController : Controller
    {

        DAL.Esteira_DAL esteira_DAL = new DAL.Esteira_DAL();

        // GET: Departamento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _ListaEsteiras(int? id_esteira)
        {
            var esteiras = esteira_DAL.ListaEsteira();
            ViewBag.esteiras = esteiras;
            ViewBag.id_esteira = id_esteira;
            return PartialView(esteiras);
        }
    }
}