using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class CanalController : Controller
    {
        DAL.Canal_DAL canal_DAL = new DAL.Canal_DAL();
        // GET: Canal
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult _ListaCanais()
        {
            var canais = canal_DAL.ListaCanais().Where(x => x.Ativo == true).OrderBy(x => x.Ds_Canal);      
                       
            return View(canais);
        }
    }
}