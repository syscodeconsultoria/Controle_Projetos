﻿using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class OrigemController : Controller
    {
        DAL.Origem_DAL origem_DAL = new DAL.Origem_DAL();
        RelacionamentosController relacionamentosController = new RelacionamentosController();
        // GET: Origem
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult _ListaOrigens(string tipoLista, int? id_iniciativa)
        {

            List<Checkados> checkados = new List<Checkados>();
            checkados = relacionamentosController.BuscaCheckados(id_iniciativa, "origens", "id_projeto", "id_origem", null, null);
            ViewBag.Checkadas = checkados;
            var origens = origem_DAL.ListaOrigens();

       
            ViewBag.origens = origens;

            //if (tipoLista == "drop")
            //{
            //    ViewBag.tipoLista = tipoLista;
            //    ViewBag.origensInDrop = origens;
            //}
            //else
            //{

            //    List<SelectListItem> listInfo = new List<SelectListItem>();

            //    foreach (var x in origens)
            //    {
            //        listInfo.Add(new SelectListItem() { Text = x.Ds_Origem, Value = x.Id_Origem.ToString() });

            //    }

            //    List<string> selectedValues = new List<string>();

            //    MultiSelectList models = new MultiSelectList(listInfo, "Value", "Text", selectedValues);
            //    ViewBag.origens = models;

            //}
            return View();      
        }

        public bool AddRemoveOrigem (int cod_origem, bool marcado, int id_projeto)
        {


            return true;

        }

    }
}
