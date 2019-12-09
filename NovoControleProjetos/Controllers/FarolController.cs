using NovoControleProjetos.DAL;
using NovoControleProjetos.Models;
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

        public bool InsereComentarioFarol(Farol farol, int? id_iniciativa, int? id_farol, int? id_comentario_farol, string oper)
        {
            return dbFarol.InsereComentarioFarol(farol, id_iniciativa, id_farol, id_comentario_farol, oper);
        }
        

      
        public Farol BuscaFarol(int? id_iniciativa, int? id_farol)
        {            
            return dbFarol.BuscaFarolComentario(id_iniciativa, id_farol, null);
        }

        public JsonResult BuscaFarolJS(int? id_iniciativa, int? id_farol)
        {
            var farol = dbFarol.BuscaFarolComentario(id_iniciativa, id_farol, null);

            var _resultado = Json(farol, JsonRequestBehavior.AllowGet);

            return _resultado;
        }
    }
}