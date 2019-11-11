using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class JornadaController : Controller
    {
        // GET: Jornada
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