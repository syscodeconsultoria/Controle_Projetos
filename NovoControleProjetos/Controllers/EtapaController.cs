

using NovoControleProjetos.Models;
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
        RelacionamentosController relacionamentosController = new RelacionamentosController();

        public ActionResult _ListaEtapas(string tipoLista, int? id_etapa, int? id_iniciativa)
        {

            List<Checkados> checkados = new List<Checkados>();
            if(id_iniciativa != null) { 
            checkados = relacionamentosController.BuscaCheckados(id_iniciativa, "etapas", "id_projeto", "id_etapa", "dt_inicio", "dt_fim");
                
            ViewBag.Checkadas = checkados;
            }





            ViewBag.id_etapa = id_etapa;
            var etapas = etapa_DAL.ListaEtapas().Where(x => x.Ativo == true).OrderBy(x => x.Ds_Etapa);
            //var etapas = _etapas.Where(x => x.Ativo == true).OrderBy(x => x.Ds_Etapa);

            if (tipoLista == "drop")
            {
                ViewBag.tipoLista = tipoLista;
                ViewBag.etapasInDrop = etapas;

            }
            else
            {
               
                //List<SelectListItem> listInfo = new List<SelectListItem>();

                //foreach (var x in etapas)
                //{
                //    listInfo.Add(new SelectListItem() { Text = x.Ds_Etapa, Value = x.Id_Etapa.ToString() });
                //    //listInfo.Add(new SelectListItem() { Text = "Prioritários Departamento", Value = "1" });
                //    //listInfo.Add(new SelectListItem() { Text = "Workshop", Value = "2" });
                //    //listInfo.Add(new SelectListItem() { Text = "PF", Value = "1" });
                //    //listInfo.Add(new SelectListItem() { Text = "PJ", Value = "1" });
                //    //listInfo.Add(new SelectListItem() { Text = "Consignado", Value = "1" });
                //    //listInfo.Add(new SelectListItem() { Text = "Oferta de valor", Value = "1" });
                //    //listInfo.Add(new SelectListItem() { Text = "POBJ", Value = "1" });

                //}

                //List<string> selectedValues = new List<string>();

                //MultiSelectList models = new MultiSelectList(listInfo, "Value", "Text", selectedValues);
                ViewBag.etapas = etapas;               
             
            }
            return View(etapas);
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