using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class IniciativaController : Controller
    {
        DAL.Iniciativa_DAL iniciativa_DAL = new DAL.Iniciativa_DAL();
        OrcamentoController orcamentoController = new OrcamentoController();
        RelacionamentosController relacionamentosController = new RelacionamentosController();


        // GET: Iniciativa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            var projeto = iniciativa_DAL.GetIniciativa(id);
            return View(projeto);
        }

        [HttpPost]
        public ActionResult Create(Iniciativa iniciativa, Orcamento orcamento, List<Origem> origens, List<Etapa> etapas, List<Vertical> verticais,
                                  List<Canal> canais, Visita visita, Jornada jornada, Ceti ceti, Replanejamento replanejamento)
        {

            try
            {

                if (verticais != null)
                {
                    bool Ok = relacionamentosController.RelacionamentosProjetoComListas(iniciativa.Id_Iniciativa, verticais.Select(x => x.Id_Vertical).ToList(), "Verticais");
                    if (!Ok)
                    {
                        return new HttpStatusCodeResult(404);
                    }
                }
                else
                {
                    bool Ok = relacionamentosController.DeletaRelacionamento(iniciativa.Id_Iniciativa, "projeto_verticais", "id_projeto");
                    if (!Ok)
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }

                if (origens != null)
                {
                    bool Ok = relacionamentosController.RelacionamentosProjetoComListas(iniciativa.Id_Iniciativa, origens.Select(x => x.Id_Origem).ToList(), "Origens" );
                    if (!Ok)
                    {
                        return new HttpStatusCodeResult(404);
                    }
                }
                else
                {
                    bool Ok = relacionamentosController.DeletaRelacionamento(iniciativa.Id_Iniciativa, "projeto_origens", "id_projeto");
                    if (!Ok)
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }

                if (etapas != null)
                {
                    bool Ok = relacionamentosController.RelacionamentosProjetoComListas(iniciativa.Id_Iniciativa, etapas.Select(x => x.Id_Etapa).ToList(), "Etapas" );
                    if (!Ok)
                    {
                        return new HttpStatusCodeResult(404);
                    }
                }
                else
                {
                    bool Ok = relacionamentosController.DeletaRelacionamento(iniciativa.Id_Iniciativa, "projeto_etapas", "id_projeto");
                    if (!Ok)
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }
                

                if (canais != null)
                {
                    bool Ok = relacionamentosController.RelacionamentosProjetoComListas(iniciativa.Id_Iniciativa, canais.Select(x => x.Id_Canal).ToList(), "Canais");
                    if (Ok)
                    {
                        return new HttpStatusCodeResult(404);
                    }
                }
                else
                {
                    bool Ok = relacionamentosController.DeletaRelacionamento(iniciativa.Id_Iniciativa, "projeto_canais", "id_projeto");
                    if (!Ok)
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }


                int idOrcamento = orcamentoController.InsereOrcamento(orcamento, iniciativa.Id_Iniciativa);

                iniciativa.id_orcamento = idOrcamento;
                //relacionamentosController.RelacionamentoOrcamentoProjeto(iniciativa.Id_Iniciativa, idOrcamento);          

                iniciativa_DAL.UpdateIniciativa(iniciativa);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                
                throw;
            }

           

        }           
           

        public ActionResult _InsertIniciativa()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult _InsertIniciativa(string nome)
        {
            var id = iniciativa_DAL.RetornaIdIniciativa(nome);
            return Json(id,JsonRequestBehavior.AllowGet);
        }

        public ActionResult _DetalhesIniciativa()
        {
            return PartialView();
        }

        public ActionResult ErroAmigavel()
        {
            return View();
        }
    }
}

