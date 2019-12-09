using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class MegaController : Controller
    {
        DAL.Mega_DAL mega_Dal = new DAL.Mega_DAL();
        
        // GET: Mega
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _ListaMegas(int? id_mega)
        {
            var megas = mega_Dal.ListaMegas();
            ViewBag.megas = megas;
            ViewBag.id_mega = id_mega;
            return PartialView(megas);
        }
    }
}