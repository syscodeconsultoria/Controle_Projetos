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

        public ActionResult Create()
        {
            return View();
        }
    }
}