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
        public ActionResult _ListaFarol()
        {
            var farois = dbFarol._ListaFarol();
            ViewBag.farois = farois;
            return PartialView(farois);
        }
    }
}