using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class VerticalController : Controller
    {
        DAL.Vertical_DAL vertical_DAL = new DAL.Vertical_DAL();
        RelacionamentosController relacionamentosController = new RelacionamentosController();

        // GET: Vertical
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _ListaVerticais(string tipoLista, int? id_iniciativa)
        {


            List<Checkados> checkados = new List<Checkados>();
            checkados = relacionamentosController.BuscaCheckados(id_iniciativa, "verticais", "id_projeto", "id_vertical");
            ViewBag.Checkadas = checkados;
            var verticais = vertical_DAL.ListaVerticais();
            ViewBag.verticais = verticais;

            //if (tipoLista == "drop")
            //{
            //    ViewBag.tipoLista = tipoLista;
            //    ViewBag.verticaisInDrop = verticais;
            //}
            //else
            //{

            //    List<SelectListItem> listInfo = new List<SelectListItem>();

            //    foreach (var x in verticais)
            //    {
            //        listInfo.Add(new SelectListItem() { Text = x.Ds_Vertical, Value = x.Id_Vertical.ToString() });

            //    }

            //    List<string> selectedValues = new List<string>();

            //    MultiSelectList models = new MultiSelectList(listInfo, "Value", "Text", selectedValues);
            //    ViewBag.verticais = models;

            //}
            return View();
        }
    }
}