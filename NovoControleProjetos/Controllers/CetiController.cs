using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class CetiController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
        // GET: Ceti

        NovoControleProjetos.DAL.Ceti_DAL ceti_DAL = new DAL.Ceti_DAL();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int InsereCeti(Ceti ceti, int? id_iniciativa, int? id_ceti, string oper)
        {
            var idCeti = ceti_DAL.InsereCetiRetornaId(ceti, id_iniciativa, id_ceti, oper);
            return idCeti;
        }

        public Ceti BuscaCeti(int? id_iniciativa, int? id_ceti)
        {
            var ceti = ceti_DAL.BuscaCeti(id_ceti, null, null);

            return ceti;
        }

    }
}

        
    