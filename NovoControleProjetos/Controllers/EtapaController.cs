

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class EtapaController : Controller
    {
        DAL.Etapa_DAL etapa_DAL = new DAL.Etapa_DAL();
        public ActionResult _ListaEtapas()
        {

            var etapas = etapa_DAL.ListaEsteira().ToList();
            List<SelectListItem> listInfo = new List<SelectListItem>();

            foreach(var x in etapas)
            { 
                listInfo.Add(new SelectListItem() { Text = x.Ds_Etapa, Value = x.Id_Etapa.ToString() });
            }
            
            List<string> selectedValues = new List<string>();
            
            MultiSelectList models = new MultiSelectList(listInfo, "Value", "Text", selectedValues);
            ViewBag.etapas = models;
            ViewBag.total = models.Count();
            return View();
        }

    }
}


//namespace NovoControleProjetos.Controllers
//{
//    public class EtapaController : Controller
//    {
//        DAL.Etapa_DAL etapa_DAL = new DAL.Etapa_DAL();
//        // GET: Etapa
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult _ListaEtapas()
//        {
//            var etapas = etapa_DAL.ListaEsteira();
//            ViewBag.etapas = etapas;
//            return PartialView(etapas);
//        }
//    }
//}