using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class ReplanejamentoController : Controller
    {

        DAL.Replanejamento_DAL replanejamento_DAL = new DAL.Replanejamento_DAL();

   
        // GET: Replanejamento
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int InsereReplanejamento(Replanejamento replanejamento, int? id_iniciativa, int? id_replanejamento, string oper)
        {
            var idReplanejamento = replanejamento_DAL.InsereReplanejamentoRetornaId(replanejamento, id_iniciativa, id_replanejamento, oper);
            return idReplanejamento;
        }

        public Replanejamento BuscaReplanejamento(int? id_iniciativa, int? id_replanejamento)
        {
            var replanejamento = replanejamento_DAL.BuscaReplanejamento(id_replanejamento, null, null);

            return replanejamento;
        }
    }
}