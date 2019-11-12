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
        DAL.Iniciativa_DAL iniciativa = new DAL.Iniciativa_DAL();
        // GET: Iniciativa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            var projeto = iniciativa.GetIniciativa(id);
            return View(projeto);
        }

        [HttpPost]
        public ActionResult Create(Iniciativa model)
        {
            iniciativa.UpdateIniciativa(model);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult _InsertIniciativa()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult _InsertIniciativa(string nome)
        {
            var id = iniciativa.RetornaIdIniciativa(nome);
            return Json(id,JsonRequestBehavior.AllowGet);
        }
    }
}