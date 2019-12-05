using NovoControleProjetos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class FarolController : Controller
    {
        private Farol_DAL dbFarol = new Farol_DAL();

        // GET: Farol
        public ActionResult _ListaFarol(int? id_farol, string cor_farol, string ds_farol)
        {
            var farois = dbFarol._ListaFarol();
            ViewBag.farois = farois;
            ViewBag.id_farol = id_farol;
            ViewBag.cor_farol = cor_farol;
            ViewBag.ds_farol = ds_farol;

            return PartialView(farois);
        }
    }
}