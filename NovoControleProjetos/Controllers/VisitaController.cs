﻿using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class VisitaController : Controller
    {

        DAL.Visita_DAL visita_DAL = new DAL.Visita_DAL();
        // GET: Visita
        public ActionResult Index()
        {
            return View();
        }

        public Visita BuscaVisita(int? id_visita, int? id_iniciativa)
        {
            return visita_DAL.BuscaVisita(id_visita, null);
        }

        public int InsereVisita(Visita visita, int? id_iniciativa, int? id_visita, string oper)            
        {
            var idVisita = visita_DAL.InsereVisita(visita, id_iniciativa, id_visita, oper);
            return idVisita;
        }
    }
}