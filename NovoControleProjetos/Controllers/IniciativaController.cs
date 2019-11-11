using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class IniciativaController : Controller
    {
        // GET: Iniciativa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            return View();
        }

        public ActionResult _InsertIniciativa()
        {
            return PartialView();
        }

        //[HttpPost]
        //public JsonResult _InsertIniciativa(string nome)
        //{
        //    return Json();
        //}
    }
}