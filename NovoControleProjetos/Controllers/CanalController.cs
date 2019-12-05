using NovoControleProjetos.Models;
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
        RelacionamentosController relacionamentosController = new RelacionamentosController();
        // GET: Canal
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult _ListaCanais(int? id_canal, int? id_iniciativa)
        {

            List<Checkados> checkados = new List<Checkados>();
            if (id_iniciativa != null)
            {
                checkados = relacionamentosController.BuscaCheckados(id_iniciativa, "canais", "id_projeto", "id_canal", "dt_canal", null);

                ViewBag.Checkadas = checkados;
            }

            var canais = canal_DAL.ListaCanais().Where(x => x.Ativo == true).OrderBy(x => x.Ds_Canal);      
                       
            return View(canais);
        }
    }
}